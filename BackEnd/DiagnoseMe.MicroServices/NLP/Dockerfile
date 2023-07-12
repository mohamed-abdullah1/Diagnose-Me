# Use the official Python base image
FROM python:3.9-slim

# Set the working directory in the container
WORKDIR /nlp

# Copy the requirements file to the container
COPY DiagnoseMe.MicroServices/NLP/requirements.txt .

# Install the Python dependencies
RUN pip install --no-cache-dir -r requirements.txt

# Copy the application code to the container
COPY DiagnoseMe.MicroServices/NLP/ .

# Set the environment variable for Flask
ENV FLASK_APP=app.py

# Expose the port on which the Flask app will run
EXPOSE 5000

# Run the Flask app when the container starts
CMD ["python3", "app.py"]
