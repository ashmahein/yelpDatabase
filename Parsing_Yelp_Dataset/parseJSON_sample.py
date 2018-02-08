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
            outfile.write(str([item for item in  data['categories']])+'\t') #category list
            outfile.write(str([])) # write your own code to process attributes
            outfile.write(str([])) # write your own code to process hours
            outfile.write('\n');

            line = f.readline()
            count_line +=1
    print(count_line)
    outfile.close()
    f.close()
    pass

def parseUserData():
    #write code to parse yelp_user.JSON
    pass

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
    with open('.\yelp_checkin.JSON','r') as f:  #Assumes that the data files are available in the current directory. If not, you should set the path for the yelp data files.
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
    pass


def parseReviewData():
    #write code to parse yelp_review.JSON
    pass

parseBusinessData()
parseUserData()
parseCheckinData()
parseReviewData()
