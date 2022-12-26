CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `event_management`.`forthcoming_events_view` AS
    SELECT 
        `e`.`Id` AS `Id`,
        `e`.`Title` AS `Title`,
        `e`.`Date` AS `Date`,
        `e`.`Description` AS `Description`,
        `e`.`DailySchedule` AS `DailySchedule`,
        `l`.`City` AS `City`,
        `l`.`Street` AS `Street`,
        `l`.`Number` AS `Number`,
        `g`.`Title` AS `GroupName`
    FROM
        (((`event_management`.`event` `e`
        JOIN `event_management`.`location` `l` ON ((`e`.`LOCATION_Id` = `l`.`Id`)))
        JOIN `event_management`.`organizes` `o` ON ((`o`.`EVENT_Id` = `e`.`Id`)))
        JOIN `event_management`.`group` `g` ON ((`o`.`GROUP_Id` = `g`.`Id`)))
    WHERE
        (`e`.`Date` > CURDATE())