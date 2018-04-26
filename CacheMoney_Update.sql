UPDATE business
SET numcheckins =
(SELECT COUNT (*) FROM checkin
WHERE checkin.busid = business.busid);

UPDATE business
SET reviewcount =
(SELECT COUNT (*) FROM reviewtable
WHERE business.busid = reviewtable.busid);

UPDATE business
SET reviewratings =
(SELECT SUM(stars) FROM reviewtable
WHERE business.busid = reviewtable.busid) /
(SELECT COUNT (*) FROM reviewtable
WHERE business.busid = reviewtable.busid);

CREATE OR REPLACE FUNCTION increaseCheckIn() Returns Trigger AS'
Begin
	UPDATE business
        SET numcheckins = numcheckins + 1
        WHERE busid = NEW.busid;
    RETURN NEW;
END
' Language plpgsql;

CREATE TRIGGER numCheckinTrigger
AFTER INSERT ON Checkin 
FOR EACH ROW
EXECUTE PROCEDURE increaseCheckIn();

Create Trigger updateCheckinTrigger
After update on checkin
For each row
Execute procedure increaseCheckIn();

CREATE OR REPLACE FUNCTION updateReviewRating() Returns Trigger AS'
Begin
	 UPDATE business
     	SET reviewratings = 
        (SELECT AVG(stars) FROM reviewtable
         WHERE busid = NEW.busid)
		Where busid = NEW.busid;
     RETURN NEW;
END
' Language plpgsql;
 
CREATE TRIGGER reviewRatingTrigger
AFTER INSERT ON reviewtable
FOR EACH ROW
EXECUTE PROCEDURE updateReviewRating();

CREATE OR REPLACE FUNCTION updateReviewCount() Returns Trigger AS'
Begin
	UPDATE business
        SET reviewCount =
        (SELECT COUNT (*) FROM reviewtable
        WHERE busid = NEW.busid)
		WHERE busid = NEW.busid;
    RETURN NEW;
END
' Language plpgsql;

CREATE TRIGGER reviewcountTrigger
AFTER INSERT ON reviewtable
FOR EACH ROW
EXECUTE PROCEDURE updateReviewCount();
