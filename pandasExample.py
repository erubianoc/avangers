import numpy as vp
import pandas as pad
dicc = {'PAIS': ["colombia", 'peru' , 'panama' , 'ecuador'], 'CAPITAL': ["bogota" , 'lima' ,'city of panam' , 'quito'] , "poblacion"  : [100000,200000,300000 , 50000]   }
print ("hola" , type (dicc))

a = pad.DataFrame.from_dict (dicc)
b = pad.DataFrame (dicc)
print (a)
#iteracion 
for i , rows in a.iterrows() :
    print (i)
    print (rows)
#adicionar columnas 
for i , rows in a.iterrows():
    a.loc[i,"siglaPais"] = rows['PAIS'][:2] # substring en py es con slice
print (a)
# aveces no es muy eficiente con for podemos usar el metodo aply en la observacion 

a["lenPais"] = a['PAIS'].apply(len) # reodrdemos aisgnacion de col a DICT la misma vaina

print (a)
print (b.describe())

# filtrar INTERESANTE COMO SE USA FILTRAMOS LA COL POBLACION (,) Y LE INDICO QUE COLUMNAS QUIERO ME TRAIGA
print (a.loc[a["poblacion"] > 100000 , ['PAIS' , 'CAPITAL']])





"""
Cuadrar este ejemplo
con este recuerdo como traigo df apartir de condiciones
"""
# Initialize reader object: urb_pop_reader
urb_pop_reader = pd.read_csv('ind_pop_data.csv', chunksize=1000)

# Get the first DataFrame chunk: df_urb_pop
df_urb_pop = next(urb_pop_reader)

# Check out the head of the DataFrame
print(df_urb_pop.head())

# Check out specific country: df_pop_ceb
df_pop_ceb = df_urb_pop[df_urb_pop['CountryCode'] == 'CEB']

# Zip DataFrame columns of interest: pops
pops = zip(df_pop_ceb ['Total Population'], df_pop_ceb ['Urban population (% of total)'])

# Turn zip object into list: pops_list
pops_list = list(pops)

# Print pops_list
print(pops_list)