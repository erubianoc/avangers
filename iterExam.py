"""
Existen  iterables e iteradores
los iterables pueden ser listas,diccionarios,file
lo iteradores son los que actuan sobre los iterables en base de la funcion next()
"""

datos = [1,2,3,4,4]
myIterador = iter(datos)
print (next(myIterador))
print (next(myIterador))
print (next(myIterador))

#enumerate iterador mas pro 
#este me devuelve el index de la lista
for i in enumerate(datos , start = 10 ):
    print(i)
#si queiro separar el indide de la lista
for i,v in enumerate(datos):
    print(v)#v es el valor
#con dict sale notemos que la clave sera el iterable no mostrara el valor 
myDci = {"nombre" : 'edwin' , 'apellido' : 'rubiano'}
for i,v in enumerate(myDci):
    print ('{}:{}' .format(i,v))
#zip generador de tuplas de list
mutants = ('nocture','nekko','lux','galio' )
powers = ('asession','mago','support','tank')
z1 = zip(mutants , powers )
# Print the tuples in z1 by unpacking with *
print(*z1) # CON * puedo mostrar todos los objetos de un iterable
z1 = zip(mutants , powers )

# miren como se puede hacer una deestruturacio o unpack MUYYY INTERESANTE
result1, result2 = list(zip(*z1))
print(result1 == mutants)
print(result2 == powers)
