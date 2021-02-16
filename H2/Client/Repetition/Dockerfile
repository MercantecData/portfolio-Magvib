FROM node:14
WORKDIR /usr/src/app
COPY /server/package*.json ./
RUN npm install
COPY . .
EXPOSE 3000
CMD [ "node", "server/index.js" ]

# docker build . -t repetition:latest
# docker run -d -p 3001:3000 repetition:latest
