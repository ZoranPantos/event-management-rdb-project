CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `event_management`.`forthcoming_events_view` AS
    SELECT 
        `e`.`Title` AS `Event`,
        `g`.`Title` AS `Group`,
        `e`.`Date` AS `Date`,
        `l`.`City` AS `City`
    FROM
        (((`event_management`.`event` `e`
        JOIN `event_management`.`organizes` `o` ON ((`e`.`Id` = `o`.`EVENT_Id`)))
        JOIN `event_management`.`group` `g` ON ((`o`.`GROUP_Id` = `g`.`Id`)))
        JOIN `event_management`.`location` `l` ON ((`e`.`LOCATION_Id` = `l`.`Id`)))
    WHERE
        (NOW() <= `e`.`Date`)