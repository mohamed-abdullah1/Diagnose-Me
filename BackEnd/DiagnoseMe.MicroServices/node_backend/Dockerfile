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


FROM node:lts-alpine

# Set up a non-root user
RUN groupadd -r node_user && useradd -r -g node_user node_user

WORKDIR /app
EXPOSE 6060

ENV MONGO_URI=mongodb+srv://Hamza:<PASSWORD>@cluster0.fwaagpt.mongodb.net/?retryWrites=true&w=majority
ENV DATABASE_PASSWORD=Mahmoud333
ENV JWT_SECRET=xeiQuai0ohc2Tha@
ENV Issuer=DiagnoseMeApi
ENV Audience=DiagnoseMeApiUsers

# Set the working directory inside the container
USER node_user

# Copy the package.json and package-lock.json files to the working directory
# COPY DiagnoseMe.MicroServices/node_backend/ nodeapis/
COPY ["DiagnoseMe.MicroServices/node_backend/package.json", "DiagnoseMe.MicroServices/node_backend/package-lock.json*", "DiagnoseMe.MicroServices/node_backend/npm-shrinkwrap.json*","./"] 

# COPY package*.json ./
# Install the application dependencies
RUN npm install

COPY DiagnoseMe.MicroServices/node_backend .

# Specify the command to run your application
CMD [ "npm", "start" ]

