```mermaid
---
title: Worklogs
---

erDiagram
    Worklogs {
        Id uuid PK
        TaskId uuid
        UserId int

        TimeSpent time
        CreatedAt timestamp
    }
```