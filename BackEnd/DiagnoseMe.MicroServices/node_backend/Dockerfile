FROM node:lts-alpine

WORKDIR /app

ENV MONGO_URI=mongodb+srv://Hamza:<PASSWORD>@cluster0.fwaagpt.mongodb.net/?retryWrites=true&w=majority
ENV DATABASE_PASSWORD=Mahmoud333
ENV JWT_SECRET=xeiQuai0ohc2Tha@
ENV Issuer=DiagnoseMeApi
ENV Audience=DiagnoseMeApiUsers
 
COPY DiagnoseMe.MicroServices/node_backend/package*.json ./
# COPY package*.json ./
RUN npm install

COPY DiagnoseMe.MicroServices/node_backend/ . 

EXPOSE 6060
# RUN chown -R node /app
# USER node

CMD [ "npm", "start" ]

