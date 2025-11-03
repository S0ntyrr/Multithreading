Multithreading en Python
Este proyecto demuestra el uso de multithreading en Python para mejorar el rendimiento en tareas que involucran operaciones de E/S (entrada/salida) intensivas.

📋 Descripción
El proyecto compara el tiempo de ejecución entre:

Ejecución secuencial: Procesa tareas una por una

Ejecución con hilos: Procesa múltiples tareas simultáneamente usando threads

🚀 Características
Simulación de tareas de E/S: Descargas de archivos y procesamiento de datos

Comparativa de rendimiento: Mide y compara tiempos de ejecución

Implementación simple: Código claro y fácil de entender

Configurable: Número de tareas y tiempos de espera personalizables

📊 Resultados Esperados
https://via.placeholder.com/600x400/4CAF50/FFFFFF?text=Secuencial+vs+Multithreading

Como se puede observar en la gráfica, el multithreading ofrece mejoras significativas en tareas de E/S.

🛠️ Instalación
bash
# Clonar el repositorio
git clone https://github.com/S0ntyrr/Multithreading.git

# Navegar al directorio
cd Multithreading

# El proyecto no requiere dependencias externas
# Solo Python 3.6+
💻 Uso
python
# Ejecutar el script principal
python multithreading_demo.py
Ejemplo de Salida:
text
Iniciando ejecución secuencial...
Tarea 1 completada (3.00s)
Tarea 2 completada (2.00s)
Tarea 3 completada (1.00s)
Tiempo secuencial total: 6.00 segundos

Iniciando ejecución con hilos...
Tarea 3 completada (1.00s)
Tarea 2 completada (2.00s)
Tarea 1 completada (3.00s)
Tiempo con hilos total: 3.00 segundos

Mejora de rendimiento: 50.0%
🏗️ Estructura del Proyecto
text
Multithreading/
│
├── multithreading_demo.py    # Script principal con la demostración
├── requirements.txt          # Dependencias del proyecto
├── README.md                # Este archivo
└── assets/                  # Imágenes y recursos
    ├── diagrama-flujo.png
    └── comparativa-tiempos.png
🔧 Cómo Funciona
Ejecución Secuencial
https://via.placeholder.com/400x200/2196F3/FFFFFF?text=Ejecuci%C3%B3n+Secuencial

python
def ejecucion_secuencial(tareas):
    inicio = time.time()
    for tarea in tareas:
        simular_descarga(tarea)
    return time.time() - inicio
Ejecución con Hilos
https://via.placeholder.com/400x200/FF9800/FFFFFF?text=Ejecuci%C3%B3n+con+Hilos

python
def ejecucion_con_hilos(tareas):
    inicio = time.time()
    hilos = []
    for tarea in tareas:
        hilo = threading.Thread(target=simular_descarga, args=(tarea,))
        hilos.append(hilo)
        hilo.start()
    
    for hilo in hilos:
        hilo.join()
    return time.time() - inicio
📈 Análisis de Rendimiento
Número de Tareas	Tiempo Secuencial	Tiempo con Hilos	Mejora
3 tareas	6.00s	3.00s	50%
5 tareas	15.00s	5.00s	66%
10 tareas	55.00s	10.00s	82%
⚠️ Limitaciones
GIL (Global Interpreter Lock): En Python, los hilos no son ideales para tareas intensivas en CPU

Overhead: Crear muchos hilos puede tener overhead

Complejidad: Mayor complejidad en el debugging y sincronización

🎯 Casos de Uso Ideales
✅ Descargas de archivos múltiples

✅ Peticiones HTTP simultáneas

✅ Procesamiento de datos con E/S

✅ Servidores web

✅ scraping web

🤝 Contribuciones
¡Las contribuciones son bienvenidas! Por favor:

Fork el proyecto

Crea una rama para tu feature (git checkout -b feature/AmazingFeature)

Commit tus cambios (git commit -m 'Add some AmazingFeature')

Push a la rama (git push origin feature/AmazingFeature)

Abre un Pull Request

📝 Licencia
Este proyecto está bajo la Licencia MIT - ver el archivo LICENSE para más detalles.

👨‍💻 Autor
S0ntyrr - GitHub

⭐ ¡Si te gusta este proyecto, dale una estrella en GitHub!
