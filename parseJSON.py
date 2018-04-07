import json

def cleanStr4SQL(s):
    return s.replace("'","`").replace("\n"," ")

def parseBusinessData():
    #read the JSON file
    with open('.\yelp_business.JSON','r') as f:  #Assumes that the data files are available in the current directory. If not, you should set the path for the yelp data files.
        outfile =  open('business.txt', 'w')
        line = f.readline()
        count_line = 0
        #read each JSON abject and extract data
        while line:
            data = json.loads(line)
            outfile.write(cleanStr4SQL(data['business_id'])+'\t') #business id
            outfile.write(cleanStr4SQL(data['name'])+'\t') #name
            outfile.write(cleanStr4SQL(data['address'])+'\t') #full_address
            outfile.write(cleanStr4SQL(data['state'])+'\t') #state
            outfile.write(cleanStr4SQL(data['city'])+'\t') #city
            outfile.write(cleanStr4SQL(data['postal_code']) + '\t')  #zipcode
            outfile.write(str(data['latitude'])+'\t') #latitude
            outfile.write(str(data['longitude'])+'\t') #longitude
            outfile.write(str(data['stars'])+'\t') #stars
            outfile.write(str(data['review_count'])+'\t') #reviewcount
            outfile.write(str(data['is_open'])+'\t') #openstatus                 
            outfile.write("\nCatagories:\t")
            outfile.write(str([item for item in data['categories']]) +',\t') #category list
            outfile.write("\nAttributes:\t")#Attributes
            for y in data['attributes']:
                if isinstance(data['attributes'][y], dict):
                    x = data['attributes'].get(y)
                    for z in x:
                        outfile.write("(" + str(z) + ',' + str(x[z]) + ")\t")
                else:
                    outfile.write( "(" + str(y) +','+ str(data['attributes'][y]) + ")\t")
            outfile.write("\nHours:\t") #HOURS
            outfile.write("[")
            for y in data['hours']:
                x = (str(data["hours"][y])).split("-")
                outfile.write("(" + str(y))
                for j in x:
                    outfile.write("," + j)
                outfile.write( ")\t")
            outfile.write("]\n")
            outfile.write('\n');
            outfile.write('\n');
            line = f.readline()
            count_line +=1
    print(count_line)
    outfile.close()
    f.close()


def parseReviewData():
    #write code to parse yelp_review.JSON
    with open('yelp_review.JSON','r') as f:
        outfile = open('review.txt', 'w')
        line = f.readline()
        countline = 0
        #read each JSON object and extract data
        while line:
            data = json.loads(line)
            outfile.write(cleanStr4SQL(data['review_id'])+'\t') #review id
            outfile.write(cleanStr4SQL(data['user_id'])+'\t') #user id
            outfile.write(cleanStr4SQL(data['business_id'])+'\t') #business id
            outfile.write(str(data['stars'])+'\t') #stars
            outfile.write(cleanStr4SQL(data['date'])+'\t') #date
            outfile.write(cleanStr4SQL(data['text'])+'\t') #text
            outfile.write('\n')
            line = f.readline()
            countline += 1
        print("Number of lines: ", countline)
        outfile.close()
        f.close()

def parseUserData():
    #write code to parse yelp_review.JSON
    with open('yelp_user.JSON','r') as f:
        outfile = open('user.txt', 'w')
        line = f.readline()
        countline = 0
        #read each JSON object and extract data
        while line:
            data = json.loads(line)
            outfile.write(str(data['average_stars'])+'\t') #average stars
            outfile.write(str(data['compliment_cool'])+'\t') #compliment cool
            outfile.write(str(data['compliment_cute'])+'\t') #compliment cute
            outfile.write(str(data['compliment_funny'])+'\t') #compliment funny
            outfile.write(str(data['compliment_hot'])+'\t') #compliment hot
            outfile.write(str(data['compliment_list'])+'\t') #compliment list
            outfile.write(str(data['compliment_more'])+'\t') #compliment more
            outfile.write(str(data['compliment_note'])+'\t') #compliment note
            outfile.write(str(data['compliment_photos'])+'\t') #compliment photos
            outfile.write(str(data['compliment_plain'])+'\t') #compliment plain
            outfile.write(str(data['compliment_profile'])+'\t') #compliment profile
            outfile.write(str(data['compliment_writer'])+'\t') #compliment writer
            outfile.write(str(data['cool'])+'\t') #cool
            outfile.write(str([item for item in  data['elite']])+'\t') #elite
            outfile.write(str(data['fans'])+'\t') #fans
            outfile.write(str([item for item in  data['friends']])+'\t') #friends
            outfile.write(str(data['funny'])+'\t') #funny
            outfile.write(cleanStr4SQL(data['name'])+'\t') #name
            outfile.write(str(data['review_count'])+'\t') #review count
            outfile.write(str(data['useful'])+'\t') #useful
            outfile.write(cleanStr4SQL(data['user_id'])+'\t') #user ID
            outfile.write(cleanStr4SQL(data['yelping_since'])+'\t') #yelping since
            outfile.write('\n')
            line = f.readline()
            countline += 1
        print("User Data Lines: ", countline)
        outfile.close()
        f.close()

def parseCheckinData():
    D={}
    morning = 0
    afternoon = 0
    evening = 0
    night = 0
    #MORNING
    L1 = ["6:00", "7:00", "8:00", "9:00", "10:00", "11:00"]
    #AFTERNOON
    L2 = ["12:00", "13:00", "14:00", "15:00", "16:00"]
    #EVENING
    L3 = ["17:00", "18:00", "19:00", "20:00", "21:00", "22:00"]
    #NIGHT
    L4 = ["23:00", "0:00", "1:00", "2:00", "3:00", "4:00", "5:00"]
    #write code to parse yelp_checkin.JSON
    with open('yelp_checkin.JSON','r') as f:  #Assumes that the data files are available in the current directory. If not, you should set the path for the yelp data files.
        outfile =  open('checkin.txt', 'w')
        line = f.readline()
        count_line = 0
        #read each JSON abject and extract data
        while line:
            data = json.loads(line)
            D=eval(line)
            for x in D:
                if(x == "time"):
                    y = D.get(x)
                    for d in y:
                        Day = d
                        outfile.write(Day + '\t')
                        morning = 0
                        afternoon = 0
                        evening = 0
                        night = 0
                        h = y.get(d)
                        for v in h:
                            value = h.get(v)
                            if(v in L1):
                                morning += value
                            elif(v in L2):
                                afternoon += value
                            elif(v in L3):
                                evening += value
                            elif(v in L4):
                                night += value
                        outfile.write(str(morning)+'\t'+str(afternoon)+'\t'+str(evening)+'\t'+str(night)+'\t')
                else:
                    business = D.get(x)
                    outfile.write(business + '\t')
                        
            outfile.write('\n');
            line = f.readline()
            count_line +=1
    print(count_line)
    outfile.close()
    f.close()


parseBusinessData()
parseReviewData()
parseUserData()
parseCheckinData()
