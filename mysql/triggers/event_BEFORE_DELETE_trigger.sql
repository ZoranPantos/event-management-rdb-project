CREATE TRIGGER event_BEFORE_DELETE BEFORE DELETE
ON event_management.`event` FOR EACH ROW
BEGIN
  DELETE FROM event_management.organizes WHERE EVENT_Id=OLD.Id;
  DELETE FROM event_management.sponsors WHERE EVENT_Id=OLD.Id;
  DELETE FROM event_management.has WHERE EVENT_Id=OLD.Id;
  DELETE FROM event_management.applies_to WHERE EVENT_Id=OLD.Id;
END