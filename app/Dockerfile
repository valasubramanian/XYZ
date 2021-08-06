FROM node:12.14.0-alpine as build
WORKDIR /app

COPY package.json ./
COPY package-lock.json ./
RUN npm install

COPY . ./

CMD ["npm", "start"]