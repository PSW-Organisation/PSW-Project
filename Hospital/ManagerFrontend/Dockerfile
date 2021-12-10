# # Stage 1: Compile and Build angular codebase

# # Use official node image as the base image
# FROM node:latest as build

# # Set the working directory
# # WORKDIR /usr/local/app
# WORKDIR /usr/src/app

# COPY package.json package-lock.json ./

# # Add the source code to app
# # COPY ./ /usr/local/app/

# COPY . .

# # Install all the dependencies
# RUN npm install

# # Generate the build of the application
# RUN npm run build --prod


# # Stage 2: Serve app with nginx server

# # Use official nginx image as the base image
# FROM nginx:latest

# # Copy the build output to replace the default nginx contents.
# COPY --from=build /usr/local/app/dist/ManagerFrontend/ /usr/share/nginx/html

# # Expose port 80
# EXPOSE 80

FROM node:16-alpine3.12 as node
WORKDIR /app
COPY Hospital/ManagerFrontend .
RUN npm install
RUN npm run build --prod

FROM nginx:alpine
COPY --from=node /app/dist/ManagerFrontend /usr/share/nginx/html