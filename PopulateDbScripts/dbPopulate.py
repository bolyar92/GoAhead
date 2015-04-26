import datetime
import random
from pymongo import MongoClient
import pymongo
import threading
import time

# Establish a connection
client = MongoClient('localhost', 27017)
db = client['SN']

# Lists with ids
users_ids= ["user_" + str(i) for i in range(100)]
images_ids = ["image_" + str(i) for i in range(100)]
places_ids = ["place_" + str(i) for i in range(100)]
comments_ids = ["comment_" + str(i) for i in range(100)]
tags_ids = ["tag_" + str(i) for i in range(100)]

# Remove all documents from collections
db.users.remove()
db.images.remove()
db.places.remove()
db.comments.remove()
db.tags.remove()

# Initialize MongoDB collections
users_collection = db.users
images_collection = db.images
places_collection = db.places
comments_collection = db.comments
tags_collection = db.tags

# Populate user_collection
def task1():
    print("Task 1 started")
    for i, id in enumerate(users_ids):
        name = "Username " + str(i)
        friends = random.sample(users_ids,random.randint(0,10))
        places = random.sample(places_ids,random.randint(0,10))
        comments = random.sample(comments_ids,random.randint(0,10))
        images = random.sample(images_ids,random.randint(0,10))
        
        user = {"alias": id, "name": name, "friends": friends, "images": images, "places": places}
        users_collection.insert_one(user)
    print("Task 1 finished")
    
# Populate comments_collection
def task2():
    print("Task 2 started")
    for i, id in enumerate(comments_ids):
        text = "Bla bla bla le bla " + str(i)
        tags = random.sample(tags_ids,random.randint(0,10))
        replies = random.sample(comments_ids,random.randint(0,10))
        user_id = users_ids[random.randint(0,len(users_ids)-1)]
        
        comment = {"alias": id, "user": user_id, "text": text, "tags": tags, "replies": replies}
        comments_collection.insert_one(comment)
    print("Task 2 finished")  
  
# Populate images_collection
def task3():
    print("Task 3 started")
    for i, id in enumerate(images_ids):
        description = "Around the world " + str(i)
        tags = random.sample(tags_ids,random.randint(0,10))
        comments = random.sample(comments_ids,random.randint(0,10))
        likedBy = random.sample(users_ids,random.randint(0,10))
        
        image = {"alias": id, "description": description, "tags": tags, "comments": comments, "likedBy": likedBy}
        images_collection.insert_one(image)
    print("Task 3 finished")
 
# Populate places_collection
def task4():
    print("Task 4 started")
    for i, id in enumerate(places_ids):
        name = "Moscow " + str(i)
        likedBy = random.sample(users_ids,random.randint(0,10))
        
        place = {"alias": id, "name": name, "likedBy": likedBy}
        places_collection.insert_one(place)
    print("Task 4 finished")
    
# Populate tags_collection
def task5():
    print("Task 5 started")
    for i, id in enumerate(tags_ids):
        text = "#hashtag " + str(i)
        taggedBy = random.sample(users_ids,random.randint(0,10))
        
        tag = {"alias": id, "text": text, "taggedBy": taggedBy}
        tags_collection.insert_one(tag)
    print("Task 5 finished")
 
# Start timer
start = time.clock()

t1 = threading.Thread(target=task1)
t2 = threading.Thread(target=task2)
t3 = threading.Thread(target=task3)
t4 = threading.Thread(target=task4)
t5 = threading.Thread(target=task5)

t1.start()
t2.start()
t3.start()
t4.start()
t5.start()

t1.join()
t2.join()
t3.join()
t4.join()
t5.join()

# Stop timer
elapsed = (time.clock() - start)
print("Time elapsed " + str(elapsed))