# ElasticSearchFootballerExample
Adding Footballers Data to ElasticSearch
1) In powershell run docker-compose -f docker-compose.elastic.yml up This will start ElasticSearch on your local. 
![Elasticsearch Docker](https://github.com/atahanceylan/ElasticSearchFootballerExample/blob/main/powershell_command_docker.PNG)

2) You check ElasticSearch is working on your local via http://localhost:9200 URL from browser.
![Elasticsearch First Open](https://github.com/atahanceylan/ElasticSearchFootballerExample/blob/main/elastic_search_first_open.PNG)

3) Now we can run our project via Visual Studio. It will open with Swagger UI screen. You can enter footballer value and it will be indexed to ElasticSearch as players index(http://localhost:9200/players/_search) 
![Add Players Via Swagger UI](https://github.com/atahanceylan/ElasticSearchFootballerExample/blob/main/add_players_to_elasticsearch_players_index.PNG)

Nest Client https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/nest.html used inside project to send data ElasticSearch

4) By this URL you will see added player data http://localhost:9200/players/_search
![Added players in ElasticSearch](https://github.com/atahanceylan/ElasticSearchFootballerExample/blob/main/elastic_search_players_index.PNG)

This project built on top of this https://blexin.com/en/blog-en/how-to-integrate-elasticsearch-in-asp-net-core/ article.
