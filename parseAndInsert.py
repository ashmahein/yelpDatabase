import json
import psycopg2

def cleanStr4SQL(s):

    sList = list(s)
    i = 0
    size = len(s)
    while i < size:
        if (sList[i] == '\''):
            sList[i] = '\'' + sList[i]
            s = "".join(sList)
            i += 1
        i += 1
    print(s)

    return s.replace("'","`").replace("\n"," ")

def int2BoolStr (value):
    if value == 0:
        return 'False'
    else:
        return 'True'




def insert2BusinessTable():
    #reading the JSON file
    with open('.//yelp_business.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('.//yelp_business.SQL', 'w')  #uncomment  this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        #TODO: update the database name, username, and password
        try:
            conn = psycopg2.connect("dbname='yelpdb' user='postgres' host='localhost' password='Khan1992'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            #Generate the INSERT statement for the cussent business
            #TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statment based on your own table schema ans
            # include values for all businessTable attributes


            sql_str = "INSERT INTO Business (BusID, bname, addr,city, state_,postalCode,latitude,longitude,bStars,reviewcount,isOpen,reviewRatings,numCheckins) " \
                      "VALUES ('" + \
                      cleanStr4SQL(data['business_id']) + "','" + \
                      cleanStr4SQL(data['name']) + "','" +\
                      cleanStr4SQL(data["address"]) + "','" + \
                      cleanStr4SQL(data["city"]) + "','" + \
                      cleanStr4SQL(data["state"]) + "','" + \
                      cleanStr4SQL(data["postal_code"]) + "'," + \
                      str(data["latitude"]) + "," + \
                      str(data["longitude"]) + "," + \
                      str(data["stars"]) + "," + \
                      str(data["review_count"]) + "," + \
					  int2BoolStr(data["is_open"]) + \
					  ",0 ," + \
                      "0" + ");" + "\n"
            #print(sql_str)
            try:
                cur.execute(sql_str)
            except:
                print("Insert to businessTABLE failed!\n")
            conn.commit()
            # optionally you might write the INSERT statement to a file.
            #outfile.write(sql_str)

            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()

    print(count_line)
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()	
	

	
def insert2UserTable():
    with open('.//yelp_user.JSON','r') as f:    #TODO: update path for the input file
        outfile =  open('.//yelp_user.SQL', 'w')  #uncomment  this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        try:
            conn = psycopg2.connect("dbname='yelpdb' user='postgres' host='localhost' password='Khan1992'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()


        while line:
            data = json.loads(line)
            sql_str = "INSERT INTO userTable (userID, Uname, yelpingSince,funny,cool,useful,fans,reviewCount,avgStar) " \
                      "VALUES ('" + \
                      cleanStr4SQL(data['user_id']) + "','" + \
                      cleanStr4SQL(data["name"]) + "','" + \
                      cleanStr4SQL(data["yelping_since"]) + "','" + \
                      str(data["compliment_funny"]) + "','" + \
                      str(data["compliment_cool"]) + "','" + \
                      str(data["useful"]) + "'," + \
                      str(data["fans"]) + "," + \
                      str(data["review_count"]) + "," + \
                      str(data["average_stars"]) + \
                      ");"
            try:
                cur.execute(sql_str)
            except:
                print("Insert to userTABLE failed!")
                outfile.write(sql_str)
            conn.commit()
            # optionally you might write the INSERT statement to a file.
            #outfile.write(sql_str)

            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()

    outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()
	
def insert2ReviewTable():
    with open('.//yelp_review.JSON','r') as f:    #TODO: update path for the input file
        outfile =  open('.//yelp_user.SQL', 'w')  #uncomment  this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        try:
            conn = psycopg2.connect("dbname='yelpdb' user='postgres' host='localhost' password='Khan1992'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            sql_str = "INSERT INTO ReviewTable (reviewID,userID,busID,text,date_,cool,useful,funny,stars) " \
                      "VALUES ('" + \
					  cleanStr4SQL(data['review_id']) + "','" + \
					  cleanStr4SQL(data['user_id']) + "','" + \
                      cleanStr4SQL(data['business_id']) + "','" + \
                      cleanStr4SQL(data["text"]) + "','" + \
                      cleanStr4SQL(data["date"]) + "','" + \
                      str(data["cool"]) + "','" + \
                      str(data["useful"]) + "'," + \
                      str(data["funny"]) + "," + \
                      str(data["stars"]) + \
                      ");"
            try:
                cur.execute(sql_str)
            except:
                print("Insert to ReviewTABLE failed!")
                outfile.writelines(sql_str)
            conn.commit()
            # optionally you might write the INSERT statement to a file.
            #outfile.writelines(sql_str)

            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()


    outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()
	

def insert2FriendsTable():
    with open('.//yelp_user.JSON','r') as f:    #TODO: update path for the input file
        outfile =  open('.//yelp_user.SQL', 'w')  #uncomment  this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        try:
            conn = psycopg2.connect("dbname='yelpdb' user='postgres' host='localhost' password='Khan1992'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            friends = data['friends']
            for x in friends:
                sql_str = "INSERT INTO FriendsTable (userID,friendID) " \
			  "VALUES ('" + \
                          cleanStr4SQL(data['user_id']) + "','" + \
                          cleanStr4SQL(x) + \
                          "');"
                try:
                    cur.execute(sql_str)
                except:
                    print("Insert to friendsTABLE failed!")
                conn.commit()
                outfile.writelines(sql_str)
            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()


    outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()
	
def insert2CategoriesTable():
    #reading the JSON file
    with open('.//yelp_business.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('.//yelp_business.SQL', 'w')  #uncomment  this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        #TODO: update the database name, username, and password
        try:
            conn = psycopg2.connect("dbname='yelpdb' user='postgres' host='localhost' password='Khan1992'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            #Generate the INSERT statement for the cussent business
            #TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statment based on your own table schema ans
            # include values for all businessTable attributes
            c = data['categories']
            for x in c:
                sql_str = "INSERT INTO Categories (cname) " \
						  "VALUES ('" + \
						  cleanStr4SQL(x) + \
						  "');"
				#print(sql_str)
                try:
                    cur.execute(sql_str)
                except:
                    print("Insert to CategoriesTable failed!\n")
                conn.commit()
                #outfile.write(sql_str)
            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()

    print(count_line)
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()
	
	
def insert2BusinessCategoriesTable():
    #reading the JSON file
    with open('.//yelp_business.JSON','r') as f:    #TODO: update path for the input file
        outfile =  open('.//yelp_business.SQL', 'w')  #uncomment  this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        #TODO: update the database name, username, and password
        try:
            conn = psycopg2.connect("dbname='yelpdb' user='postgres' host='localhost' password='Khan1992'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            #Generate the INSERT statement for the cussent business
            #TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statment based on your own table schema ans
            # include values for all businessTable attributes
            c = data['categories']
            for x in c:
                sql_str = "INSERT INTO BusinessCategories (busID,cname) " \
						  "VALUES ('" + \
						  cleanStr4SQL(data['business_id']) + "','" + \
						  cleanStr4SQL(x) + \
						  "');"
				#print(sql_str)
                try:
                    cur.execute(sql_str)
                except:
                    print("Insert to BusinessCategoriesTable failed!\n")
                    outfile.write(sql_str)
                conn.commit()
                #outfile.write(sql_str)
            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()

    print(count_line)
    outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()


def insert2CheckinTable():
    #reading the JSON file
    with open('.//yelp_checkin.JSON','r') as f:    #TODO: update path for the input file
        outfile =  open('.//yelp_checkin.SQL', 'w')  #uncomment  this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        #TODO: update the database name, username, and password
        try:
            conn = psycopg2.connect("dbname='yelpdb' user='postgres' host='localhost' password='Khan1992'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            L1 = ["6:00", "7:00", "8:00", "9:00", "10:00", "11:00"]
            L2 = ["12:00", "13:00", "14:00", "15:00", "16:00"]
            L3 = ["17:00", "18:00", "19:00", "20:00", "21:00", "22:00"]
            L4 = ["23:00", "0:00", "1:00", "2:00", "3:00", "4:00", "5:00"]
			
            D=eval(line)
            for x in D:
                if(x == "time"):
                    y = D.get(x)
                    for d in y:
                        DayOfWeek = d
                        L = [0,0,0,0]
                        h = y.get(d)
                        for v in h:
                            value = h.get(v)
                            if(v in L1):
                                L[0] += value
                            elif(v in L2):
                                L[1] += value
                            elif(v in L3):
                                L[2] += value
                            elif(v in L4):
                                L[3] += value
                        sql_str = "INSERT INTO CheckIn (busID,DayOfWeek,morning,afternoon,evening,night) " \
                                  "VALUES ('" + \
                                  cleanStr4SQL(data['business_id']) + "','" + \
                                  cleanStr4SQL(DayOfWeek)+ "','" + \
                                  str(L[0]) + "','" + \
                                  str(L[1]) + "','" + \
                                  str(L[2]) + "','" + \
                                  str(L[3]) + \
                                  "');"
                        try:
                            cur.execute(sql_str)
                        except:
                            print("Insert to checkinTable failed!\n")
                            outfile.write(sql_str)
                        conn.commit()
                #outfile.write(sql_str)
            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()

    print(count_line)
    outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()	





def insert2AttributeTable():
    #reading the JSON file
    with open('.//yelp_business.JSON','r') as f:    #TODO: update path for the input file
        outfile =  open('.//yelp_business.SQL', 'w')  #uncomment  this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        #TODO: update the database name, username, and password
        try:
            conn = psycopg2.connect("dbname='yelpdb' user='postgres' host='localhost' password='Khan1992'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            #Generate the INSERT statement for the cussent business
            #TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statment based on your own table schema ans
            # include values for all businessTable attributes
            a = data['attributes']
            

            for x in data['attributes']:
                if isinstance(data['attributes'][x], dict):
                    y = data['attributes'].get(x)
                    for z in y:
                        sql_str = "INSERT INTO Attributes (aname) " \
                                  "VALUES ('" + \
                                  cleanStr4SQL(z) + \
                                  "');"
                        try:
                            cur.execute(sql_str)
                        except:
                            print("Insert to AttributesTable failed!\n")
                            outfile.write(sql_str)
                        conn.commit()
                else:
                    sql_str = "INSERT INTO Attributes (aname) " \
                              "VALUES ('" + \
                              cleanStr4SQL(x) + \
                              "');"
                    try:
                        cur.execute(sql_str)
                    except:
                        print("Insert to AttributesTable failed!\n")
                        outfile.write(sql_str)
                    conn.commit()

            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()

    print(count_line)
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()


def insert2BusinessAttributeTable():
    #reading the JSON file
    with open('.//yelp_business.JSON','r') as f:    #TODO: update path for the input file
        outfile =  open('.//yelp_business.SQL', 'w')  #uncomment  this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        #TODO: update the database name, username, and password
        try:
            conn = psycopg2.connect("dbname='yelpdb' user='postgres' host='localhost' password='Khan1992'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            #Generate the INSERT statement for the cussent business
            #TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statment based on your own table schema ans
            # include values for all businessTable attributes
            a = data['attributes']
            L=['False']

            for x in data['attributes']:
                if isinstance(data['attributes'][x], dict):
                    y = data['attributes'].get(x)
                    for z in y:
                        if y[z] not in L:
                            sql_str = "INSERT INTO BusinessAttributes (busID,aname,value_) " \
                                      "VALUES ('" + \
                                      cleanStr4SQL(data['business_id']) + "','" + \
                                      cleanStr4SQL(z) + "','" + \
                                      str(y[z]) + \
                                      "');"
                            try:
                                cur.execute(sql_str)
                            except:
                                print("Insert to BusinessAttribute failed!\n")
                                outfile.write(sql_str)
                            conn.commit()
                else:
                    if data['attributes'][x] not in L:
                        sql_str = "INSERT INTO BusinessAttributes (busID,aname,value_) " \
                                  "VALUES ('" + \
                                  cleanStr4SQL(data['business_id']) + "','" + \
                                  cleanStr4SQL(x) + "','" + \
                                  str(data['attributes'][x]) + \
                                  "');"
                        try:
                            cur.execute(sql_str)
                        except:
                            print("Insert to BusinessAttribute failed!\n")
                            outfile.write(sql_str)
                        conn.commit()

            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()

    print(count_line)
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()	

	
def insert2BusinessHoursTable():
    #reading the JSON file
    with open('.//yelp_business.JSON','r') as f:    #TODO: update path for the input file
        outfile =  open('.//yelp_business.SQL', 'w')  #uncomment  this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        #TODO: update the database name, username, and password
        try:
            conn = psycopg2.connect("dbname='yelpdb' user='postgres' host='localhost' password='Khan1992'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            for y in data['hours']:
                x = (str(data["hours"][y])).split("-")
                DOW=y
                openBus=x[0]
                closeBus=x[1]
                sql_str = "INSERT INTO Hours (busID,dayOfWeek,opens,closed) " \
                          "VALUES ('" + \
                          cleanStr4SQL(data['business_id']) + "','" + \
                          str(DOW) + "','" + \
                          str(openBus) + "','" + \
                          str(closeBus)+ \
                          "');"
                try:
                    cur.execute(sql_str)
                except:
                    print("Insert to BusinessCategoriesTable failed!\n")
                    outfile.write(sql_str)
                conn.commit()
            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()

    print(count_line)
    outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()	

#insert2CategoriesTable()
#insert2BusinessTable()
#insert2UserTable()
#insert2ReviewTable()
#insert2FriendsTable()
#insert2BusinessCategoriesTable()
insert2CheckinTable()
#insert2AttributeTable()
#insert2BusinessAttributeTable()
#insert2BusinessHoursTable()
