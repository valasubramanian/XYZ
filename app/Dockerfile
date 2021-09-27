FROM node:12.14.0-alpine as build
WORKDIR /app
EXPOSE 82

COPY package.json ./
COPY package-lock.json ./
RUN npm install

COPY . ./

CMD ["npm", "start"]