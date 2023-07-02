# Specify the base image
FROM node:17

# Set the working directory inside the container
WORKDIR /app

# Copy the package.json and package-lock.json files to the working directory
COPY package*.json ./

# Install the application dependencies
RUN npm install

# Copy the rest of the application code
COPY . .

# Specify the command to run your application
CMD [ "node", "server.js" ]

EXPOSE 6060
