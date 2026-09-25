using Task3.workspace;
using Task3.workspace.items;

await TestingState.RunTests();

public record PrintJob(string Name, string User, Priority Priority);
public record PrintLog(string Name, string User, DateTime PrintedAt);