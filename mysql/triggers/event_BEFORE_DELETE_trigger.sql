DROP TRIGGER IF EXISTS `event_management`.`event_BEFORE_DELETE`;

DELIMITER $$
USE `event_management`$$

CREATE DEFINER = CURRENT_USER TRIGGER `event_management`.`event_BEFORE_DELETE` BEFORE DELETE ON `event` FOR EACH ROW
BEGIN
  DELETE FROM event_management.organizes WHERE EVENT_Id=OLD.Id;
  DELETE FROM event_management.sponsors WHERE EVENT_Id=OLD.Id;
  DELETE FROM event_management.has WHERE EVENT_Id=OLD.Id;
  DELETE FROM event_management.applies_to WHERE EVENT_Id=OLD.Id;
END$$

DELIMITER ;