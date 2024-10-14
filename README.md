# TRIDENT_Project
專案描述:設計選課系統API與相應資料庫和單元測試，資料庫的結構和資料可以透過StudentEnrollmentSystem.sql取得，Api可以在SwaggerUI中直接測試。   

專案環境:
開發工具：VS 2022   
使用語言：C#   
後端框架：ASP.NET CORE 6 WEB API   
ORM框架：EF CORE   
資料庫：SQL Server   
單元測試：NUnit   

流程:   
首先以DB First為目標，先預訂規格，然後將資料表實作，再使用ORM工具將資料表Mapping到Api專案中，製作單元測試，接著開始設計api，最後單元測試通過後，加上swagger完成   


# 資料庫 StudentEnrollmentSystem

## 學生資料表 (Students)
| 欄位名稱    | 類型     | 必填 | 描述           |
|------------|----------|------|---------------|
| id         | int      | 是   | 唯一識別碼     |
| name       | string   | 是   | 學生姓名       |
| email      | string   | 否   | 電子郵件地址   |
| createdDate| datetime | 是   | 帳號建立時間   |
| updatedDate| datetime | 是   | 帳號更新時間   |

## 教授資料表 (Professors)
| 欄位名稱    | 類型     | 必填 | 描述           |
|------------|----------|------|---------------|
| id         | int      | 是   | 唯一識別碼     |
| name       | string   | 是   | 教授姓名       |
| email      | string   | 否   | 電子郵件地址   |
| createdDate| datetime | 是   | 帳號建立時間   |
| updatedDate| datetime | 是   | 帳號更新時間   |

## 課程資料表 (Courses)
| 欄位名稱    | 類型     | 必填 | 描述           |
|------------|----------|------|---------------|
| id         | int      | 是   | 唯一識別碼     |
| courseName | string   | 是   | 課程名稱       |
| professorId| int      | 是   | 授課教授Id     |
| createdDate| datetime | 是   | 課程建立時間   |
| updatedDate| datetime | 是   | 課程更新時間   |

## 學生選課關聯表 (StudentCourse)
| 欄位名稱    | 類型     | 必填 | 描述           |
|------------|----------|------|---------------|
| id         | int      | 是   | 唯一識別碼     |
| studentId  | int      | 是   | 學生Id         |
| courseId   | int      | 是   | 課程Id         |
| enrollDate | datetime | 是   | 選課日期       |

## API端點定義

課程列表 API (GET /api/courses)

回傳：課程ID、課程名稱、教授ID、教授姓名、教授Email


授課講師列表 API (GET /api/professors)

回傳：教授ID、姓名、Email


授課講師所開課程列表 API (GET /api/professors/{professorId}/courses)

回傳：課程ID、課程名稱


建立新講師 API (POST /api/professors)

接收：姓名、Email
回傳：新建立的教授資訊


建立新課程 API (POST /api/courses)

接收：課程名稱、教授ID
回傳：新建立的課程資訊


更新課程內容 API (PUT /api/courses/{courseId})

接收：課程名稱、教授ID（可選）
回傳：更新後的課程資訊


刪除課程 API (DELETE /api/courses/{courseId})

回傳：成功或失敗的狀態



目前進度API開發和單元測試，Swagger文檔皆設計完成，對於人員登入、課程時間等，因另外還有設計想法，尚未完成。   
## 尚未實作的部分   
人員登入的部分，預計將使用JWT來取得和授權Token，這部分將參考之前的Sideo Project [Jackmazon_backend](https://github.com/suzijie860706/Jackmazon_backend) 實現
課程時間將會另外設計資料表CourseSchedules，來儲存當建立課程時，可以設定課程的上、下課時間，每周的上課日   
資料表預定   
CREATE TABLE CourseSchedules (   
    ScheduleID INT PRIMARY KEY IDENTITY,   
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),   
    DayOfWeek TINYINT, -- 1 = 星期一, 2 = 星期二, 以此類推   
    StartTime TIME,   
    EndTime TIME,   
    CONSTRAINT UQ_CourseSchedule UNIQUE (CourseID, DayOfWeek)   
);   