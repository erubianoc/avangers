"""
comprimir loops en una simple linea
componentes
    itarables
    iterator varaible(que representa los miembros de una variable iterable)
    o la salida de una expresion
su sintaxis es 
BASICA
    [OUTPUT EXPRESION FOR ITERATOR VARIABLE IN ITARABLE]
COMPLEX
    [OUTPUT EXPRESION + CONDICION DEL OUPUT FOR VARAIBLE IN ITERABLE + CONDICIONAL DEL ITERADOR]
"""
# Create list comprehension: squares
squares = [i ** 2 for i in range(0,10)]
print(squares)

# Create a 5 x 5 matrix using a list of lists: matrix 
matrix = [[col for col in range(5)] for i in range(5)]

# Print the matrix
for row in matrix:
    print(row)

# list comprehension conditionasl
fellowship = ['frodo', 'samwise', 'merry', 'aragorn', 'legolas', 'boromir', 'gimli']
# en esta condicionamos el iterador member 
#digo mande member a la lista si se cumple la condicion si no ''
#este seria como una especie de map
new_fellowship = [member if len(member) >= 7 else  ''  for member in fellowship]
print(new_fellowship)


#este basicamente como member no tiene un else si no que si se cumple se va seria como una 
#especie de filter
fellowship = ['frodo', 'samwise', 'merry', 'aragorn', 'legolas', 'boromir', 'gimli']
new_fellowship = [member for member in fellowship if len(member) >= 7 ]
print(new_fellowship)


# Create a list of strings: fellowship
fellowship = ['frodo', 'samwise', 'merry', 'aragorn', 'legolas', 'boromir', 'gimli']

# Create dict comprehension: new_fellowship
new_fellowship = {member : len (member) for member in fellowship }

# Print the new dictionary
print(new_fellowship)


"""
    con dataframes aca no funciona por que no esta cargado el DF este lo saque de datacamp
"""
# Extract the created_at column from df: tweet_time
tweet_time = df ['created_at']

# Extract the clock time: tweet_clock_time
tweet_clock_time = [entry[12:20] for entry in tweet_time ]

# Print the extracted times
print(tweet_clock_time)

"""
otro ejemplo
"""
# Extract the created_at column from df: tweet_time
tweet_time = df ['created_at']

# Extract the clock time: tweet_clock_time
tweet_clock_time = [entry [11:19] for entry in tweet_time if entry[17:19] == '19']

# Print the extracted times
print(tweet_clock_time)


"""
podemos mandadar funciones para armar un diccionario de comprehesion
# Print the first two lists in row_lists
print(row_lists [0])
print(row_lists [1])

# Turn list of lists into list of dicts: list_of_dicts
aca mi expresion es el llamado a una funcion que me devuelve un diccionario 
donde sublist es mi iterador
muy interesante
list_of_dicts = [lists2dict(feature_names,sublist) for sublist in row_lists]

# Print the first two dictionaries in list_of_dicts
print(list_of_dicts[0])
print(list_of_dicts[1])
"""

