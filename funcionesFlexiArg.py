# las funciones pueden tener flexibilidad en argumentos

# valores por defecto
def fun1 ( a, b = 1):
    result = a + b
    return result
print (fun1 (1)) # solo le mando a y no chilla

#por *args
def fun2(*args):
    for i in args:
        print (i)
fun2(1,2,3,4,5) # mandamos x argumentos y * los recibe todos
str("hola").upper
# por **kwargs para diccionarios
def fun3 (**kwargs):
    for a , b in kwargs.items():
        print (a , b)
fun3 (nombre = 'edwin' , apellido='rubiano')

