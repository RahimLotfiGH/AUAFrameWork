<div align="center">
 <img src="http://heilton.com/AUA_files/image002.png" alt="فریم ورک Asp.Net Unique Architecture"  width="327"  height="227" >
  </div>
<h1 color="blue" align="center" >Asp.Net Unique Architecture Framework  (AUA)</h1>

<h2>Abstract</h2>
    <div style="text-align: justify;text-justify: inter-word;">

Software projects require constant changes and updates. If the structure develops in the wrong way, it will prevent changes and extensions, and most of the time will lead to task duplication or rewriting of the project from scratch. To get rid of the complexity and task duplication that most programmers and developers face, which is also caused by the inconsistency of code at different levels of the program, we need a simple consistent structure for writing software projects so that we can hide some of the complexity and focus on business of the task. For example, the Bootstrap framework is a very useful framework for Front End, but few people would prefer to use frameworks like Bootstrap for design, and write all of their design with CSS from the beginning. For the Back End section, however, a simple, general-purpose framework can save time and cost and produce high-quality code and a uniform architecture. This framework allows developers to develop their projects based on an appropriate integrated pattern. The framework must be flexible enough to allow the programmer to apply any changes needed, relying on its robust structure.
 </div>
 
<h2>Why Framework?</h2>
One of the problems of software companies is the lack of the right structure for developing their projects. As a result, they have often produced such complex and nested codes that creating changes in one part of the project severely affects or disrupts other parts. Therefore, lack of the right structure for development makes it impossible to update the previous code and reduces the efficiency of the team to almost zero. The reason for this is the difference in coding and lack of structure and architecture. The development team must first agree on a set of rules and structures. Architectural patterns are not the result of a programmer's experiences; they have resulted from the experiences of hundreds of programmers and design professionals over years. These frameworks are not innovations or inventions, but are feedbacks on redesign and recoding that programmers have been involved with in order to achieve the highest levels of flexibility, extensibility and reusability. Their use makes the produced codes more simple, flexible and extensible. The use of a framework can help us save time and cost and make it easier to document and maintain the system.


<h2>Asp.Net Unique Architecture Framework (AUA)</h2>
AUA is a simple, lightweight framework for producing projects of any size (small and large). It can be applied in all architectures (Micro service, CQRS, etc.) due to its transparency in structure. It is also full of different design patterns, thus a great source for software architects and developers.
 <ul>
  <li>Domain Driven Design (DDD)</li>
  <li>EF 6 and EF Core 3.0,3.1</li>
  <li>Based on SOLID Principles</li>
  <li>Modular design</li>
  <li>Modular design</li>
  <li>Layered architecture</li>
</ul> 


<h2>AUA Framework's Versions:</h2>
 <ul>
  <li>Asp.Net MVC (.net framework and ef6)</li>
  <li>Asp.Net MVC Core 3.0,3.1</li>
  <li>Asp.Net Web API Core 3.0,3.1
</li>
</ul> 


<h2> AUA Framework's Overall Structure </h2>
The different layers of the AUA framework are as follows:
<ul>
        <li><strong> Common Layer</strong>  This layer contains common items used in other layers, such as Enums, Consts, Extensions,… ، Tools</li>      
        <li><strong> Data Layer</strong>  This layer contains items associated with the data source, including Entity Framework Context, Db Extensions, Search Filters, Unit of Work Pattern, Configuration Tools, and Dapper Context</li>      
        <li><strong> Domain Entity Layer</strong>  This layer contains the entities and their configuration.</li>
        <li><strong> Models Layer</strong>  This layer contains DTOs, View Models and Config mapping:
EntitiesDto, ReportModels, View Models ,</li>
        <li><strong> Service Infrastructure Layer</strong>  The overall infrastructure of Services and Repository is written and becomes ready for use in this layer.</li>
          <li><strong> Service Layer</strong>  This layer includes all the business services of your project, including BaseServices, BusinessService, EntitiesService, ReportService, etc.</li>
            <li><strong> WebApi or Ui Mvc Layer</strong>This is an interface user layer that can be written with General MVC- WebApi- GraphQl- Grapc.</li>
              <li><strong> Test Layer</strong>  This layer is designed for writing Unit Tests (ToDo)</li>
                  <li><strong> External web service Layer</strong>  This layer is for calling external services. (ToDo)</li>
    </ul>
<h2>Adding New Entity</h2>
Entity is the main concept, and indeed at the heart of the architecture of, the AUA framework. Each entity is defined by a class that contains its features and its relation to other entities. Each entity has an identifier that can be of any Data Type allowed in .NET, or it can be a combination of two or more Data Types allowed therein (combination key).

<h2>Entity Class</h2>
  Each entity inherits from the DomainEntity class, to which a primary key field called Id and one or more monitoring fields (depending on the setting type) are added.

```csharp
public class Student : DomainEntity
{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
}
```
It should be specified if the primary key has a data type other than the int data type (e.g. the Long data type is considered under the primary key)
```csharp
public class Student : DomainEntity<long>
{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
}
```
By default the following fields are added to each entity.

The <b>Id</b> key of the primary key and its data type can be specified when defining an entity.

The <b>IsActive </b>field shows whether the entity is active or inactive and it has a bool data type.

The <b> RegDate</b> displays the date and time the entity is created (automatically created inside SQL Server) and does not need to be filled in and sent.
