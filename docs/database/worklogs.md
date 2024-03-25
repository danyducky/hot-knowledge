```mermaid
---
title: Worklogs
---

erDiagram
    Worklogs {
        Id uuid PK
        TaskId uuid
        UserId int

        Description text
        TimeSpent time

        CreatedAt timestamp
    }
```