CREATE PROCEDURE user_groups_list (IN userId INT)
BEGIN
	SELECT * FROM event_management.`group` g
    WHERE g.REGULAR_USER_USER_Id=userId;
END