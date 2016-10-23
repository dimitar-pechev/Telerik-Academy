## Database Systems - Overview
### _Homework_

1.  What database models do you know?
    > Relational databases, object-oriented, hierarchical.

1.  Which are the main functions performed by a Relational Database Management System (RDBMS)?
    > They manage the stored data in tables. Allows the user to create, remove or alter tables (the data entries) or simply to retrieve some previously stored data.

1.  Define what is "table" in database terms.
    > A table is a data structure predefined with specific rules. It consists of rows and columns. The structure of each row (the data that each col should hold - 
    > the columns have name and type) is the same for the entire table. Each row has its own primary key which is unique for each row. If several cols are set as
    > primary keys that is called a composite primary key. The combination of information between these cols has to be unique.

1.  Explain the difference between a primary and a foreign key.
    > A primary key is unique for each row in the table. It is like an identifier for the row holding the data. A foreign key points usually to the unique key
    > of some other row in a different table and the specific row of information that it holds.

1.  Explain the different kinds of relationships between tables in relational databases.
    > The relationships between tables provide us a way to avoid repeting data and keep a high level of consistency of the way we provide our data.

    > **One-to-Many:** a single record in the first table has many corresponding records in the second one.

    > **Many-to-Many:** Records in the first table have many corresponding records in the second one and vice versa. This is usually achieved through a third table
    > holding information about those relations.

    > **One-to-One:** A single record in a table corresponds to a single record in the other table.

1.  When is a certain database schema normalized?
    > When all the repetions are removed and replaced with keys corresponding to values in other tables. This is a way to keep our data consistent and easily 
    > altered or updated.

1.  What are database integrity constraints and when are they used?
    > Integrity constraints are the set of rules which define the specific format of the data in our tables. They can predefine the types of values, 
    > length of the provided entry value, etc. They ensure that the primary (or composite) keys are unique and that the foreign keys do indeed point
    > to data in an existing table.

1.  Point out the pros and cons of using indexes in a database.
    > **Pros:** they speed up significantly the search process in the database. 

    > **Cons:** adding or removing data from indexed tables is slower. 

    > Which approach to use? Depends on the needs of the user. If the database is not going to be altered too often and is going to be used
    > predominantly for searching and retrieving information it should be indexed. If it's going to be used just for storing data and not retrieving it too often
    > then it should not be indexed.

1.  What's the main purpose of the SQL language?
    > **The Structured Query Language (SQL)** is a standardized declarative language for manipulation of relational databases. It supports creating, altering, 
    > deleting tables and other objects in a database as well as searching, retrieving, inserting, modifying and deleting the inserted data.

1.  What are transactions used for?
    > Database transactions are a sequence of database operations that are considered as a single operation. If one fails - the whole block of operations fails.
    > A good example could be given with money transactions by banking software. The transaction consists of two main parts. Withdrawing money from one's account
    > and sending that money to another account. If the first part succeeds but the second fails the whole operation should fail. Otherwise the first user will have lost
    > his money without actually sending them to someone else's account. That is the kind of cases in which database transactions are used. All parts of the
    > operation are considered as one. If the second part fails, the changes from the first operation will be reverted.
    > The ruling principle here is either all the parts of the entire operation pass or none of them pass.
1.  What is a NoSQL database?
    > **Not only Structured Query Language (NoSQL)** stands for a non-relational database. It adopts a document-based model that does not require predefining the rules
    > in which the database should be structured (that's actually one of the main ideas). A single entity of the data structure is a single document.
    > They allow the basic CRUD operations as well as concurreny and transactions.
    > NoSQL data structures are easier to create and are faster in many operations (search, alter, etc.) as there are no links between them and other data structures.
    > A significant drawback is the allowed lack of consistency in the stored data and repetions.

1.  Explain the classical non-relational data models.
    > **Document model:** set of documents (e. g. JSON objects).

    > **Key-value model:** set of key-value pairs.

    > **Wide-column model:** key-value model with schema.

    > **Graph model:** graph structures for semantic queries with nodes, edges and properties to represent and store data.

1.  Give few examples of NoSQL databases and their pros and cons.
    > **MongoDB:** Document-model data structure. Supports various request types including regex filtering. The data can be indexed. Data can be allocated 
    > on several servers quickly. Has support for various programming languages. JavaScript operations can even be sent with the request. 
    > cn the other hand MongoDB has been critisized over the years for its sometimes failing concurreny mechanisms which sometimes cause issues with storing data.

    > **Apache Cassandra:** Wide-column model data structure. Really good performance on speed matters and high level of reliability even for larger amounts of data.
    > The main cons are related to the data model itself. The wide-column model is basically a key-value model with applied schema. Which means that the structuring
    > of the data in the application should be well suitable to the schema in the server. That excludes the more flexible code-first approach.

    > **Redis:** Key-value model. It's an open source project with a large and active community. Fast, supports various data types.
    > Main cons are the same as with Cassandra. The Key-value model does not allow querying the database. 
