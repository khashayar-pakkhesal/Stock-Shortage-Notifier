# Stock-Shortage-Notifier
A service that checks for stocks by certain rules and notifies shortage of stock 
Architected with Clean architecture and Domain Driven Design and EDA for application layer and also used SQL server, EF Core and DotNet Core

# Architectural decisions
1- Consider Using DDD and Clean Architecture

   Decision: for a robust and scalable architecture for notifying according to rules I used DDD and clean architecture

2- using SQL server with EntityFramework Core

   Decision: I used an SQL server with EntityFramework which was the most suitable option for saving our records and fetching them 
	 
   Alternatives: PostgreSql, NHibernate

3- using the most suitable architecture for the Application layer

   Decision: I used Event-Driven Architecture for the application layer since it helped for more scalability and throwing events and also it's scalable for managing lots of events with lotf of handlers
	 
   Alternatives: Command Pattern, MediatR, RabbitMQ, Kafka
    

