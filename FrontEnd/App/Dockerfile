#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM node:16.15.1 as eauctionangularapp

RUN mkdir -p /app

WORKDIR /app

COPY package.json /app

RUN npm install

COPY . /app

RUN npm run build --prod


FROM nginx:1.17.1-alpine

COPY --from=eauctionangularapp /app/dist/App /usr/share/nginx/html
