select *
from AspNetUsers U
	INNER JOIN AspNetUserRoles UR ON U.Id = UR.UserId
		INNER JOIN AspNetRoles R ON UR.RoleId = R.Id

--select *
--from AspNetUsers U
--	INNER JOIN AspNetUserRoles UR ON U.Id = UR.UserId
--		INNER JOIN AspNetRoles R ON UR.RoleId = R.Id

--delete
--from AspNetUserRoles
--where UserId IN (
--	select UR.UserId
--from AspNetUsers U
--	INNER JOIN AspNetUserRoles UR ON U.Id = UR.UserId
--		INNER JOIN AspNetRoles R ON UR.RoleId = R.Id
--where R.Name IN ('customer', 'test')
--)
