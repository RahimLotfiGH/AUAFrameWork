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


<h2>AUA Framework's Overall Structure</h2>
The different layers of the AUA framework are as follows:
  <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Layer's Name</th>
                    <th>Use</th>                  
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Common Layer</td>
                    <td>This layer contains common items used in other layers, such as Enums, Consts, Extensions,… ، Tools </td> 
                </tr>
                 <tr>
                    <td>Data Layer</td>
                    <td>This layer contains items associated with the data source, including Entity Framework Context, Db Extensions, Search Filters, Unit of Work Pattern, Configuration Tools, and Dapper Context </td>                  
                </tr>
                 <tr>
                    <td>Domain Entity Layer</td>
                    <td>This layer contains the entities and their configuration.</td>                  
                </tr>
                 <tr>
                    <td>Models Layer</td>
                    <td>This layer contains DTOs, View Models and Config mapping:

EntitiesDto, ReportModels, View Models ,…
</td>                  
                </tr>
                 <tr>
                    <td>Service Infrastructure Layer</td>
                    <td>The overall infrastructure of Services and Repository is written and becomes ready for use in this layer.</td>                  
                </tr>
                 <tr>
                    <td>Service Layer</td>
                    <td>This layer includes all the business services of your project, including BaseServices, BusinessService, EntitiesService, ReportService, etc.</td>                  
                </tr>
                 <tr>
                    <td>WebApi or Ui Mvc Layer</td>
                    <td>This is an interface user layer that can be written with General MVC- WebApi- GraphQl- Grapc.</td>                  
                </tr>
                 <tr>
                    <td>Test Layer</td>
                    <td>This layer is designed for writing Unit Tests (ToDo)</td>                  
                </tr>
                 <tr>
                    <td>External web service Layer

</td>
                    <td>This layer is for calling external services. (ToDo)

</td>                  
                </tr>
          
            </tbody>
        </table>
