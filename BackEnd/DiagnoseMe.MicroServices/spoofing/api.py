# -*- coding: utf-8 -*-
"""
Created on Sat Jun 24 00:24:14 2023

@author: hp
"""
import cv2
import os
import numpy as np
from scipy import stats as st
from flask import Flask, request
import json
from sklearn.decomposition import FastICA
cascPathface = os.path.dirname(
    cv2.__file__) + "/data/haarcascade_frontalface_alt2.xml"
faceCascade = cv2.CascadeClassifier(cascPathface)
MIN_HR_BPM = 45.0/60
MAX_HR_BMP = 240.0/60
def dist(frame1,frame2):
    return np.sqrt(((frame1-frame2)**2).sum())
def get_color_signal():
    prev_face=None
    face=None
    facs=[]
    frames=0
    cap=cv2.VideoCapture(video_path)
    while True:
        ret,frame=cap.read()
        if ret==False:
            break
        gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
        
        faces = faceCascade.detectMultiScale(gray,
                                             scaleFactor=1.1,
                                             minNeighbors=5,
                                             minSize=(60, 60),
                                             flags=cv2.CASCADE_SCALE_IMAGE)
        frames+=1
        
        if len(faces) == 0:
            face = prev_face
        elif len(faces)>1 and prev_face is not None:
            mini_dist=float('inf')
            for fac in faces:
                dis=dist(fac,prev_face)
                if dis<mini_dist :
                    face=fac
                    mini_dist=dis
        elif len(faces)>1 and prev_face is None:
            are=0
            for fac in faces:
                are1=fac[2]*fac[3]
                if are1>are:
                    face=fac
                    are=are1
        else:
            face=faces[0]
        prev_face=face    
        if face is not None:
            
            (x, y, w, h) = face
            box=(int(x+.2*w),y,int(.8*w),h)    #we get all the height and 60% of the width 
            (x, y, w, h) = box
            backgrndMask = np.full(frame.shape, True, dtype=bool)
            backgrndMask[y:y+h, x:x+w, :] = False 
            backgrndMask[int(y + h *.25) :int( y + h * .5), :] = True
            roi = np.ma.array(frame, mask=backgrndMask)
            colorChannels = roi.reshape(-1, roi.shape[-1])
            avgColor = colorChannels.mean(axis=0)
            facs.append(avgColor) 
    fps=frames/60        
    return facs,fps                        
def detect_heart_rate(window,window_size,fps):
    mean = np.mean(window, axis=0)
    std = np.std(window, axis=0)
    normalized = (window - mean) / std  
    
    ica = FastICA()
    srcSig = ica.fit_transform(normalized)
    powerSpec = np.abs(np.fft.fft(srcSig, axis=0))**2
    freqs = np.fft.fftfreq(window_size,1.0/fps)
    maxPwrSrc = np.max(powerSpec, axis=1)
    validIdx = np.where((freqs >= MIN_HR_BPM) & (freqs <= MAX_HR_BMP))
    validPwr = maxPwrSrc[validIdx]
    validFreqs = freqs[validIdx]
    maxPwrIdx = np.argmax(validPwr)
    hr = validFreqs[maxPwrIdx]
    
    return hr            




video_path="C:\\Users\\hp\\Downloads\\video.mp4"

app = Flask(__name__)
@app.route('/uploadVideo', methods=['POST'])
def upload():
    if 'video' not in request.files:
        return 'No video file uploaded', 400

    video_file = request.files['video']

    if video_file.filename == '':
        return 'No video file selected', 400

    video_path = 'C:\\Users\\hp\\Downloads\\' + video_file.filename
    video_file.save(video_path)
    print("saved")
    
    colorsig,fps=get_color_signal()
    
    fps=int(np.ceil(fps))
    window_in_sec=30
    window_size=int(np.ceil(fps*window_in_sec))
    results=[]
    i=0
    while ((i+window_size)<=len(colorsig)):
        hr=detect_heart_rate(colorsig[i:i+window_size],window_size,fps)
        i+=fps
        results.append(hr*60)
    final_result=[]
    last_value=results[2]
    for val in results[2:]:
        if(abs(last_value-val)<12):
            final_result.append(val)
            last_value=val
            
    return json.dumps(final_result)



if __name__ == '__main__':
    app.run(debug=True)
    
    
    
    

    












































