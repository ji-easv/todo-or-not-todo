﻿using ToDoBackend.Domain.Entities;

namespace ToDoBackend.Application.Services.Interfaces;

public interface IToDoService
{
    Task CreateToDoItemAsync(ToDoItem toDoItem);
    
    Task UpdateToDoItemAsync(ToDoItem toDoItem);
    
    Task UpdateToDoItemStatusAsync(Guid toDoItemId, bool isCompleted);
    
    Task DeleteToDoItemAsync(Guid toDoItemId);
    
    Task<List<ToDoItem>> GetToDoItemsByUserIdAsync(Guid userId);
    
    Task<ToDoItem?> GetToDoItemByIdAsync(Guid toDoItemId);
}