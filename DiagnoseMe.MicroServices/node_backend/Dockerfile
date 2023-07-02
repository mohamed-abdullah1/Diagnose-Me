# # Specify the base image
# FROM node:17
# WORKDIR /app
# EXPOSE 6060

# # Set the working directory inside the container
# USER node_user

# # Copy the package.json and package-lock.json files to the working directory
# # COPY package*.json ./
# WORKDIR /src
# COPY ["DiagnoseMe.MicroServices/node_backend/", "nodeapis/"]

# WORKDIR /src/nodeapis
# # Install the application dependencies
# RUN npm install


# # Specify the command to run your application
# CMD [ "node", "server.js" ]


FROM node:17

# Set up a non-root user
RUN groupadd -r node_user && useradd -r -g node_user node_user

WORKDIR /app
EXPOSE 6060

# Set the working directory inside the container
USER node_user

# Copy the package.json and package-lock.json files to the working directory
COPY DiagnoseMe.MicroServices/node_backend/ nodeapis/

WORKDIR /app/nodeapis

# Install the application dependencies
RUN npm install

# Specify the command to run your application
CMD [ "node", "server.js" ]
