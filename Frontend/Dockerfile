FROM node:latest
WORKDIR /app
COPY . .
RUN npm install js-sha256
RUN npm run build
CMD [ "npm","start" ]