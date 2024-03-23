```mermaid
---
title: Tasks
---

erDiagram
    Tasks {
        Id uuid PK
        AssigneeUserId int FK

        Number int
        Summary text
        Shortcut varchar

        CreatedAt timestamp
        UpdatedAt timestamp
    }
```