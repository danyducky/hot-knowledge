
```mermaid
---
title: Workspaces
---

erDiagram
    Workspaces ||--o| Members : ""
    Workspaces {
        Id uuid PK
        OwnerUserId int
        Name varchar
    }

    Members {
        UserId int4 PK
        WorkspaceId uuid PK
        Status MemberStatus
    }

    MemberStatus {
        Active Zero
        Disabled One
        Invited Two
    }
```