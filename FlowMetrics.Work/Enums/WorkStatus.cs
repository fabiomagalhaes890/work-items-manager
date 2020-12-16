namespace FlowMetrics.Work.Enums
{
    public enum WorkStatus
    {
        Backlog = 0,
        ToDo = 1,
        InProgress = 2,
        AwaitingCodeReview = 3,
        Reviewing = 4,
        AwaitingTests = 5,
        Testing = 6,
        AwaitingAcceptanceTests = 7,
        TestingInAcceptance = 8,
        AwaitingProduction = 9,
        Done = 10
    }
}
