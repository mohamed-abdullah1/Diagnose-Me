# Use the official Python base image
FROM python:3.9-slim

# Set the working directory in the container
WORKDIR /spoofing

# Copy the requirements file to the container
# COPY /requirements.txt ./
# Copy the application code to the container
COPY . .

# Install the Python dependencies
RUN pip install --no-cache-dir -r requirements.txt


# Set the environment variable for Flask
ENV FLASK_APP=run.py

# Expose the port on which the Flask app will run
EXPOSE 7070

# Run the Flask app when the container starts
CMD ["python3", "run.py"]
