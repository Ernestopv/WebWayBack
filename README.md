# WebWayBack

WebWayBack is a small web application which helps to travel back in time delivering the old design from the website desired, is powered using the web API from :
[https://archive.org/help/wayback_api.php]

## Backend (REST API)
The backend was build on .netCore and consist on just two endpoints:

- `**A POST Request : /api/search (helps to find the desired website)**`

![image](https://user-images.githubusercontent.com/24325283/207930589-19678306-3239-4fe9-a314-70aa5d6564be.png)


- `**A GET Request : /health (helps to monitoring the connection from the ExternalService(WayBack Machine(external API)))**`

![image](https://user-images.githubusercontent.com/24325283/207930198-3aaa62ac-d5d4-48c9-8770-0a893c309325.png)


## Frontend 
- `**The frontend was build on React.js**`

![image](https://user-images.githubusercontent.com/24325283/207927790-773cb36c-3da8-48a5-bcfa-7abdc410813f.png)
![image](https://user-images.githubusercontent.com/24325283/207929656-0bd0ebd2-e0d2-4cc8-b5ad-02a5920440a1.png)
![image](https://user-images.githubusercontent.com/24325283/207929843-7c277373-dc8f-462e-a1a0-017a37b3e076.png)



## Docker

This solution contains a docker-compose.yaml file that defines the configuration of the container 
the user should be able to clone this repository from github and able to execute with the following commands:

`````````````````
cd {projectLocation}\WebWayBack\src
docker compose up
`````````````````

**the port configuration is 80** , but user can feel  free to change it on  **docker-compose.yaml** file 
