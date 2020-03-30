# devolviendo varios valores desde una funcion 

def estadisticas_basicas (operado , operando):
    
    suma = operado + operando
    resta = operado - operando
    multi = operado * operando
    res = (suma,resta,multi)
    return res
mysuma , myresta , mymulti = estadisticas_basicas (2 ,2)
print (mysuma , ';' , myresta , ';' , mymulti)

# funciones anidadas 

def three_shouts(word1, word2, word3):
    """Returns a tuple of strings
    concatenated with '!!!'."""

    # Define inner con esto nos ahorramos procesamiento de computo ya que a word1,2,3 los operamos en 
    #una funcion interna
    def inner(word):
        """Returns a string concatenated with '!!!'."""
        return word + '!!!'

    # Return a tuple of strings
    return (inner(word1), inner(word2),inner(word3))

# Call three_shouts() and print
print(three_shouts('a', 'b', 'c'))


'''""" RETORNAR FUNCIONES """'''
# Define echo
def echo(n):
    """Return the inner_echo function."""

    # Define inner_echo
    def inner_echo(word1):
        """Concatenate n copies of word1."""
        echo_word = word1 * n
        return echo_word

    # Return inner_echo
    return (inner_echo) # ESTAMOS RETORNANDO LA FUNCION

# Call echo: twice
twice = echo(2) # ASIGNAMOS A ESTE OBJ LA FUNCION PRINCIPAL 

# Call echo: thrice
thrice = echo(3)

# Call twice() and thrice() then print
print(twice('hello'), thrice('hello')) ##INTERESNATE LE MANDAMOS A LAS VAR ES EL ARGUMENTO DE LA FUNCION HIJA

## VARIABLES NONLOCAL Y GLOBAL IMPORTANTE APRENDER PARA EL SCPOE DE LA VARIABLE


