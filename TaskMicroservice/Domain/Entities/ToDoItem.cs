﻿namespace ToDoBackend.Domain.Entities;

public class ToDoItem
{
    public Guid Id { get; set; }
    
    public required Guid UserId { get; set; }
    
    public required string Title { get; set; }
    
    public required string Description { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public DateTime CreatedAt { get; set; }
}