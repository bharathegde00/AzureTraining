



// Construct a new "TableServiceClient using a TableSharedKeyCredential.
using Azure;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;

var serviceClient = new TableServiceClient(
    new Uri("https://trainingstorage22.table.core.windows.net"),
    new TableSharedKeyCredential("trainingstorage22", "boB+f+UlzxSqBZm/n1CozmcItijUE8PZxvwOrl4a0lIw3PFuyfMNMBswOq6fGzG4oHfDo7o6xmq2+AStQeULPA=="));

// Create a new table. The TableItem class stores properties of the created table.
string tableNamee = "MyNew";
TableItem t1 = serviceClient.CreateTableIfNotExists(tableNamee);
Console.WriteLine($"The created table's name is {t1.Name}.");

// Use the <see cref="TableServiceClient"> to query the service. Passing in OData filter strings is optional.

Pageable<TableItem> queryTableResults = serviceClient.Query(filter: $"TableName eq '{tableNamee}'");

Console.WriteLine("The following are the names of the tables in the query results:");

// Iterate the <see cref="Pageable"> in order to access queried tables.

foreach (TableItem tablee in queryTableResults)
{
    Console.WriteLine(tablee.Name);
}

//// Deletes the table made previously.
string tableeName = "MyNew";
serviceClient.DeleteTable(tableeName);

// Construct a new <see cref="TableClient" /> using a <see cref="TableSharedKeyCredential" />.
var tableClient = new TableClient(
    new Uri("https://trainingstorage22.table.core.windows.net"),
    tableNamee,
    new TableSharedKeyCredential("trainingstorage22", "boB+f+UlzxSqBZm/n1CozmcItijUE8PZxvwOrl4a0lIw3PFuyfMNMBswOq6fGzG4oHfDo7o6xmq2+AStQeULPA=="));
//tableClient.Create();

// Make a dictionary entity by defining a <see cref="TableEntity">.
var entity = new TableEntity("PartitionKey", "rowKey")
{
    { "Product", "Marker Set" },
    { "Price", 5.00 },
    { "Quantity", 21 }
};

Console.WriteLine($"{entity.RowKey}: {entity["Product"]} costs ${entity.GetDouble("Price")}.");

//// Add the newly created entity.
tableClient.AddEntity(entity);


Pageable<TableEntity> queryResultsFilter = tableClient.Query<TableEntity>(filter: $"PartitionKey eq '{"partitionKey"}'");

// Iterate the <see cref="Pageable"> to access all queried entities.
foreach (TableEntity qEntity in queryResultsFilter)
{
    Console.WriteLine($"{qEntity.GetString("Product")}: {qEntity.GetDouble("Price")}");
}

Console.WriteLine($"The query returned {queryResultsFilter.Count()} entities.");