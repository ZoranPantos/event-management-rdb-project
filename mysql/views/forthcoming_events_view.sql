CREATE VIEW forthcoming_events_view AS
SELECT e.Id, e.Title, e.`Date`, e.`Description`, DailySchedule, City, Street, `Number`, g.Title AS GroupName
FROM event_management.`event` e 
  INNER JOIN event_management.location l ON e.LOCATION_Id=l.Id
  INNER JOIN event_management.organizes o ON o.EVENT_Id=e.Id
  INNER JOIN event_management.`group` g ON o.GROUP_Id=g.Id
WHERE e.`Date`>CURRENT_DATE();