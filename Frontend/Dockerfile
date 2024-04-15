FROM node:21-alpine3.18
WORKDIR /app

ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY package.json ./
COPY package-lock.json ./
RUN npm install 
RUN npm install js-sha256

COPY . ./

RUN npm run build
CMD [ "npm","start" ]