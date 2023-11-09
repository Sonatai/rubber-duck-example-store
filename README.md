# rubber-duck-example-store

Repo: https://github.com/Sonatai/rubber-duck-example-store

## Architecture & Features

![Architecture](./docs/architecture.svg)

So, the user can register and login. Also they can see a list of products. They can add items or delete them (if enter 0). And they can check their cart via a json prompt.

## How to Setup

WSL2 need to be enabled and your Docker should use it:
https://docs.docker.com/desktop/wsl/

Open a terminal in the root folder.

### Setup Databases

Enter follow commands in your terminal:

```docker
docker pull mongo
docker run -d --name cart-mongodb -p 4300:27017 -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=1234 mongo
docker run -d --name user-mongodb -p 4310:27017 -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=1234 mongo
```

You can reach the databases via mongoshell or mongo atlas. Use this connection strings:
CartDB: mongodb://admin:1234@localhost:4300/
UserDB: mongodb://admin:1234@localhost:4310/

### Setup User Service

Enter follow commands in your terminal:

```docker
docker build .\backend\user-service\API\ -t user-service
docker run --name=user-service -p 4220:8080 -d user-service
```

You can reach the service via swagger:
http://localhost:4220/swagger/index.html

### Setup Cart Service

Enter follow commands in your terminal:

```docker
docker build .\backend\cart-service\API\ -t cart-service
docker run --name=cart-service -p 4210:8080 -d cart-service
```

You can reach the service via swagger:
http://localhost:4210/swagger/index.html

### Setup Product Catalogue Service

Enter follow commands in your terminal:

```docker
docker build ./backend/product-catalog-service/API -t product-service
docker run --name=product-service -p 4200:8080 -d product-service
```

You can reach the service via swagger:
http://localhost:4200/swagger/index.html

### Setup Frontend

Enter follow commands in your terminal:

```docker
docker build .\frontend\ -t frontend
docker run --name=frontend -p 5000:5000 -d frontend
```

You can reach the webpage via http://localhost:5000/
