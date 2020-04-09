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
By default the following fields are added to each entity.<br>
The <b>Id</b> key of the primary key and its data type can be specified when defining an entity.<br>
The <b>IsActive </b>field shows whether the entity is active or inactive and it has a bool data type.<br>
The <b> RegDate</b> displays the date and time the entity is created (automatically created inside SQL Server) and does not need to be filled in and sent.

```csharp
public class DomainEntity<TPrimaryKey> : BaseDomainEntity<TPrimaryKey>, IAuditInfo
{
   public DateTime RegDate { get; set; }
}
```

```csharp
public class BaseDomainEntity<TPrimaryKey> : IDomainEntity<TPrimaryKey>
{
        public TPrimaryKey Id { get; set; }
        public bool IsActive { get; set; }
}
```
The AUA framework is open-Source and can be easily customized.<br>
Monitoring fields:<br>
You can add more monitoring fields to the entities if you wish depending on your business.<br>
<b>Monitoring Field Creating the ICreationAudited Entity</b>

```csharp
public interface ICreationAudited
 {
     long CreatorUserId { get; set; }
}
```
To add the monitoring field of CreatorUserId, we can simply implement the ICreationAudited interface for the DomainEntity class, as follows:
```csharp
public class DomainEntity<TPrimaryKey> : BaseDomainEntity<TPrimaryKey>, IAuditInfo, ICreationAudited
{
        public DateTime RegDate { get; set; }
        public long CreatorUserId { get; set; }
}
```
<b>Auditing fields of deleting the IDeletionAudited entity</b>

The IDeletionAudited interface can be used to prevent the physical deletion and add the monitoring fields of entity deletion.
```csharp
 public interface IDeletionAudited: ISoftDelete
{
        long? DeleterUserId { get; set; }
        DateTime? DeleteDate { get; set; }
}
```
```csharp
public interface ISoftDelete
{
        bool IsDeleted { get; set; }
}
```
<b>Auditing fields for editing IModifiedAudited</b>

The IModifiedAudited interface can be used to add monitoring fields for editing an entity.
```csharp
public interface IModifiedAudited
{
        long? ModifierUserId { get; set; }
        DateTime? ModifyDate { get; set; }
}
```
<b>Configuration of entities:</b>
There is a configuration class for each entity that can specify the length of field settings for it.
```csharp
 public class StudentConfig : IEntityTypeConfiguration< Student>
    {
        public void Configure( EntityTypeBuilder<Student> builder)
        {
         builder
                .Property(p => p.FirstName)
                .HasMaxLength( LengthConsts.MaxStringLen50);

            builder
                .Property(p => p.LastName)
                .HasMaxLength( LengthConsts.MaxStringLen50);
        }
}
```
e configure the entity with the combination key as follows. The AppUserId and RoleId fields are both<br>
Keys to the UserRole entity<br>
We configure the entity with the combination key as follows. The AppUserId and RoleId fields are both keys to the UserRole entity<br>

```csharp
   public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
{
        public void Configure(EntityTypeBuilder< UserRole> builder)
        {
            builder.Ignore(p => p.Id);
            
            builder
              .HasKey(p => new { p.AppUserId, p.RoleId });
        }
}      
```
<b>Models and Mapping:</b>
Models inherit the BaseEntityDto class at AUA, and the monitoring and Id fields are added automatically to them. The AUA framework has two mapping methods of IMapFrom and IHaveCustomMappings to map one object to another. In the IMapFrom model, only fields with the same name are mapped, and there is no mapping for those with different names. This type of mapping is the simplest and fastest type of mapping. In the example below, a Student entity is mapped to a StudentDto, as follows:

```csharp
 public class StudentDto : BaseEntityDto, IMapFrom<Student>
 {
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        public string FullName => $"{FirstName} {LastName}";
}
```
<b>IHaveCustomMappings Method</b>
In the IHaveCustomMappings model, not only fields with the same name, but also each field of the source model can be mapped to the Linq commands. In this case, your map includes configuration, which is performed at the bottom of the model. This method is very flexible. Anything that can be written with the Linq commands for an entity can be written with this type of mapping. Below is a mapping example that maps an object from AppUser to AppUserDto. In addition, access levels and roles are mapped. In the reporting section, we will use complex mapping for reporting.

```csharp
public class AppUserDto: BaseEntityDto<long>, IHaveCustomMappings
{
public string FirstName { get; set; }
public string LastName { get; set; }
public string UserName { get; set; }
public string FullName => FirstName + " " + LastName;
public string Password { get; set; }
public string Phone { get; set; }
public string Email { get; set; }
public bool IsActive { get; set; }
public virtual ICollection<UserRole> UserRoles { get; set; }
public void ConfigureMapping(Profile configuration)
{
  configuration.CreateMap<AppUser, AppUserDto>()
  .ForMember(p => p.UserRoles, p => p.MapFrom(q => q.UserRoles))
  .ReverseMap();
}
}
```
<b>ConvertTo and ProjectTo Functions</b>
To help with mapping operations, you can convert an object or list of objects into one or a list of view models without any restrictions, and use IMapFrom and IHaveCustomMappings to configure mapping operations (MapperInstance is by default an instance of AutoMapper in all services). For example, we have created a view model called TestMappingVm that uses IHaveCustomMappings to configure mapping operations, thereby mapping a query of the AppUser entity to this view model using ConvertTo and ProjectTo.

```csharp
public class TestMappingVm : IHaveCustomMappings
{
        public string Email { get; set; }
        public string PersonName { get; set; }
        public int RoleCount { get; set; }
        public ICollection<Role> UserRoles { get; set; } 
        public void ConfigureMapping(Profile configuration)
        {
            configuration.CreateMap<AppUser, TestMappingVm>()
                .ForMember(p => p.PersonName, p => p.MapFrom(q => q.FirstName + " " + q.LastName))
                .ForMember(p => p.RoleCount, p => p.MapFrom(q => q.UserRoles.Count))
                .ForMember(p => p.UserRoles, p => p.MapFrom(q => q.UserRoles.Select(m => m.Role)))
                .ReverseMap();
        }
    }
```
<b>Mapping using ProjectTo:</b>
```csharp
public IEnumerable<TestMappingVm> GeTestMappingVms()
{
            var query = GetAll().Where(p => p.IsActive);
            return   MapperInstance
                    .ProjectTo<TestMappingVm>(query)
                    .ToList();
}
```
<b>Mapping using ConvertTo</b>
```csharp
public IEnumerable<TestMappingVm> GeTestMappingVms()
{
            var query = GetAll().Where(p => p.IsActive);
            return query
                     .ConvertTo<TestMappingVm>(MapperInstance)
                     .ToList();
 }
```

One of the most important features of the AUA framework is its high security. Security and performance have always been in conflict. The Heilton security team has worked hard to design a very secure way to raise security while maintaining the performance and has used it in the AUA framework.

Each view model and DTO inherit from the generic class BaseEncryptionVm <TPrimaryKey>, and two EncKeyId and DecKeyId fields are added to it.

EncKeyId is the encrypted equivalent of the primary key (Id). The encryption key is generated for each different user. If the programmer specifies this field in its Select command, it will produce its framework; otherwise, it will not produce it.

DecKeyId is equivalent to Id.<br>
In addition, the DecKeyId function has been considered in the BaseController. It receives EncKeyId and converts it to Id, and the programmer is not involved in encryption and hash algorithms under any circumstances (however, this feature can be avoided and that id may be used instead).

```csharp
public async Task<IActionResult> _Update(string keyId)
{
            var userId = DecKeyId<long>(keyId);
            var model = await _appUserService.GetAppUserVmAsync(userId);
            return View(model);
}
```

<b>Services</b>
All business is implemented in the form of services and created in the service layer. The service layer uses the Service Infrastructure layer and automatically connects to each service in its own Repository. The advantage of this approach is that the developer is not involved in the two concepts of repository and service and focuses only on the service itself. The service has its own built-in Repository, which is one of the most important features of the AUA framework architecture. For example, if we want to write a service for Student Entity, we must first create an interface for Student Entity which inherits from the IGenericEntityService class.

```csharp
 public interface IStudentService : IGenericEntityService<Student, StudentDto>
    {
    }
```

 After Interface you can create the desired service. The service must inherit from the GenericEntityService class and implement the IStudentService interface built in the previous step.
```csharp
  public class StudentService: GenericEntityService<Student,StudentDto>,IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {                     
        }
    }
```

By default, the service created contains all the functions required to work with Repository.

List of Repository functions that are automatically added to each service..

<ul>
  <li><b>GetAll</b>This returns all entities and can be filtered. It also supports Async.</li>
  <li><b>GetAllDto</b>This returns all entities in DTO format and can be filtered. It also supports Async.</li>
  <li><b>GetCount</b>Number of entities - can be filtered.</li>
  <li><b>GetFirst</b>This returns the first entity and can be filtered.</li>
  <li><b>GetCountAsync</b>Number of entities – filterable; supporting Async</li>
  <li><b>GetFirstAsync</b>This returns the first entity and can be filtered; supporting Async</li>
  <li><b>GetLastAsync</b>This returns the last entity and can be filtered; supporting Async</li>
  <li><b>GetDtoById</b>Holding entity and mapping it in DTO format</li>
  <li><b>GetByIdAsync</b>Holding entity with the primary key; supporting Async</li>
  <li><b>GetDtoByIdAsync</b>Holding entity and mapping it in DTO format; supporting Async</li>
  <li><b>Delete</b>Deleting entity with the primary key or DTO</li>
  <li><b>DeleteAsync</b>Deleting entity with the primary key or DTO; supporting Async</li>
  <li><b>Insert</b>Inserting new entity with Entity or DTO</li>
  <li><b>InsertAsync</b>Inserting new entity; supporting Async</li>
 <li><b>InsertMany</b>Inserting multiple entities simultaneously</li>
  <li><b>InsertManyAsync</b>Inserting multiple entities simultaneously; supporting Async</li>
   <li><b>InsertCustomVm</b>Inserting entity with custom view model (when part of entity fields is sent from view)

 </li>
  <li><b>InsertCustomVmAsync</b>Inserting entity with custom view model; supporting Async

</li>
   <li><b>PartialInsert</b>Inserting entity into repository without sending to database; supporting Async

</li>
  <li><b>Update</b>Editing new entity with Entity or DTO

</li>
   <li><b>UpdateAsync</b>Editing new entity with Entity or DTO; supporting Async

</li>
  <li><b>UpdateCustomVm</b>Editing entity with custom view model (when part of entity fields is sent from view)

</li>
   <li><b>UpdateCustomVmAsync</b>Editing entity with custom view model (when part of entity fields is sent from view)

</li>
  <li><b>PartialUpdate</b>Inserting entity into repository without sending to database; supporting Async

</li>
   <li><b>ConvertTo</b>This converts a query result to another object based on configuration mapping

</li>
  <li><b>ProjectTo</b>This projects a query result to another object based on configuration mapping

</li>
   <li><b>SaveChange</b>This specifies the final status when using Partial Functions.

</li>
  <li><b>SaveChangeAsync</b>This specifies the final status when using Partial Functions; supporting Async

</li>
</ul> 
The developer can implement his business into the services. One service can use other services.

You can easily inject services into another and use it.

<b>Access levels</b>
In the AUA framework, you as administrator can control the users' access to the smallest possible level. This is done by the user management module. You can assign roles to users by defining them and assigning User Access levels to them. The diagram below shows the levels of access to the AUA Word Framework.

<img src="http://heilton.com/AUA_files/image007.jpg" alt="Accounting"  width="624" height="248">

There are four models of Authentication and Authorization in the AUA framework and it is possible to specify the level of access in the controller and action.<br>0
1. WebAuthorize: This attribute allows you to specify access levels for the action and controller.<br>
2. AllowLoggedInUser: The user has just to log in.<br>
3. OnlyLocalActionAuthorize: This attribute is for actions and controllers that only need to be called locally on the server.<br>
4. AllowAnonymousAuthorize: Any user can have unlimited access to this action and controller<br>
To use WebAuthorize, you must add an item for each control or action in EUserAccess. In the database in the UserAccess table we add the name, access number, description and URL.

```csharp
public enum EUserAccess
    {
        #region Accounting
        [Description("User Management")]
        AppUser = 1,
        [Description("Access level management")]
        UserAccess = 2,
        [Description("Role management")]
        UserRole = 3,
        [Description("Role-level access management")]
        UserRoleAccess = 4,
        #endregion  
    }
```
To use WebAuthorize, you need to write it for the controller or action. For example, the following action is accessible only for users who have access to AppUser = 1.

```csharp
 [WebAuthorize(EUserAccess.AppUser)]
 public async Task<IActionResult> _Insert(AppUserDto appUserDto)
 {
            await _appUserService.InsertAsync(appUserDto);
            return RedirectToAction("Index");
}
```
WebAuthorize input can have several levels of access. That is, the user has access to that resource if he has access to one of these.

The page title is loaded by default according to the description in the UserAccess table for the page.
<b>Reporting</b>
One of the most important features of software is reporting with different capabilities and one of the concerns of programmers is the addition and modification of filters which is performed in the AUA framework easily and at a high speed and you can create your own report with various filters. To create a report, we first make a view model to apply filters and another view model to display the output and finally write our search filter to apply the filters.

For example, we create a report of all users and all their access.

View Model of Search Filter:


```csharp
 public class UserAccessReportSearchVm : BaseSearchVm
    {
        public string FirstName { get; set; }        
        public string LastName { get; set; }     
        public string UserName { get; set; }     
        public bool? IsActive { get; set; }
        public List<SelectListItem> RecordStatusItem { get; set; }     
        public string RoleTitle { get; set; }     
        public string UserAccessTitle { get; set; }
    }
```
View Model of Report output:

```csharp
     public class UserAccessReportGridVm : BaseEntityDto<long>, IHaveCustomMappings
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string RoleTitle { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Role> UserRoles { get; set; }
        public IEnumerable<UserAccess> UserAccess { get; set; }
        public string UserRolesTitles => string.Join("<br/> ", UserRoles.Select(p => p.Title));
        public string UserAccessTitles => string.Join("<br/> ", UserAccess.Select(p => p.Title));
        public void ConfigureMapping(Profile configuration)
        {
            configuration.CreateMap<AppUser, UserAccessReportGridVm>()
                .ForMember(p => p.UserRoles, p => p.MapFrom(q => q.UserRoles.Select(r => r.Role)))
                .ForMember(p => p.UserAccess, p => p.MapFrom(q => q.UserRoles.SelectMany(t =>  t.Role.UserRoleAccess.Select(m => m.UserAccess))))
                .ReverseMap();
        }
    }
```

After creating the search view and grid view of the model, we write a search filter to apply the filters.

```csharp
public class UserAccessReportFilter : Specification<AppUser>
    {
        private readonly UserAccessReportSearchVm _searchVm;
        private Expression<Func<AppUser, bool>> _expression = p => true;
        protected bool IsEmptyFilter => _searchVm == null;
        
        public UserAccessReportFilter(UserAccessReportSearchVm searchVm)
        {
            _searchVm = searchVm;
        }

        public override Expression<Func<AppUser, bool>> IsSatisfiedBy()
        {

            if (IsEmptyFilter) return p => true;
 
            ApplyDefaultFilter();
            ApplyFirstNameFilter();
            ApplyLastNameFilter();
            ApplyUserNameFilter();
            ApplyIsActiveFilter();
            ApplyRoleTitleFilter();
            ApplyUserAccessTitleFilter();
 

            return _expression;
        }

        private void ApplyDefaultFilter()
        {
        //--ToDo
        }
        
        private void ApplyFirstNameFilter()
        {
            if (string.IsNullOrWhiteSpace(_searchVm.FirstName))
                return;
                
            _expression = _expression.And(p =>      p.FirstName.Contains(_searchVm.FirstName));
        }
        
       private void ApplyLastNameFilter()
        {
            if (string.IsNullOrWhiteSpace(_searchVm.LastName))
                return;
                
            _expression = _expression.And(p => p.LastName.Contains(_searchVm.LastName));
        }
        
       private void ApplyUserNameFilter()
        {
            if (string.IsNullOrWhiteSpace(_searchVm.UserName))
                return;

            _expression = _expression.And(p => p.UserName.Contains(_searchVm.UserName));
        }
        
       private void ApplyIsActiveFilter()
        {
            if (_searchVm.IsActive == null)
                return;
                
            _expression = _expression.And(p => p.IsActive == _searchVm.IsActive);
        }

       private void ApplyRoleTitleFilter()
        {
            if (string.IsNullOrWhiteSpace(_searchVm.RoleTitle))
                return;
            _expression = _expression.And(p => p.UserRoles.Any(r => r.Role.Title.Contains(_searchVm.RoleTitle)));
        }
        
        private void ApplyUserAccessTitleFilter()
        {
            if (string.IsNullOrWhiteSpace(_searchVm.UserAccessTitle))
                return;
                
            _expression = _expression.And(p => p.UserRoles.Any(r =>
                                    r.Role.UserRoleAccess.Any(a =>
                                    a.UserAccess.Title.Contains(_searchVm.UserAccessTitle))));
        }
```

The output of this report can be viewed as follows.
<img width="610" height="150" src="http://heilton.com/AUA_files/image009.jpg" >
<img width="624" height="261" src="http://heilton.com/AUA_files/image011.jpg">
 
