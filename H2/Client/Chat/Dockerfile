FROM node:14
WORKDIR /usr/src/app
COPY /server/package*.json ./
RUN npm install
COPY . .
EXPOSE 3000
CMD [ "node", "server/index.js" ]

# docker build . -t chat:latest
# docker run -d -p 3000:3000 chat:latest