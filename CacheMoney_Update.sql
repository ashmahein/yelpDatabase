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
        SET numcheckins = OLD.numcheckins + 1
        WHERE busid = NEW.busid;
    RETURN NEW;
END
' Language plpgsql;

CREATE TRIGGER numCheckinTrigger
AFTER INSERT ON Checkin 
FOR EACH ROW
EXECUTE PROCEDURE increaseCheckIn();


CREATE OR REPLACE FUNCTION updateReviewRating() Returns Trigger AS'
Begin
	 UPDATE business
     	SET business.reviewratings = (SELECT SUM(stars) FROM reviewtable
         WHERE business.busid = reviewtable.busid) /
         (SELECT COUNT (*) FROM reviewtable
         WHERE business.busid = reviewtable.busid);
     RETURN NEW;
END
' Language plpgsql;

 
CREATE TRIGGER reviewRatingTrigger
AFTER UPDATE OF stars ON reviewtable
FOR EACH ROW
EXECUTE PROCEDURE updateReviewRating();

CREATE OR REPLACE FUNCTION updateReviewCount() Returns Trigger AS'
Begin
	UPDATE business
        SET business.reviewcount =
        (SELECT COUNT (*) FROM reviewtable
        WHERE business.busid = reviewtable.busid);
    RETURN NEW;
END
' Language plpgsql;

CREATE TRIGGER reviewcountTrigger
AFTER UPDATE OF stars ON reviewtable
FOR EACH ROW
EXECUTE PROCEDURE updateReviewCount();


 