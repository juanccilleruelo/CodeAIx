# CodeAIx
CodeAIx is an assitant for programing in any language. Is a CLI application for Codex that helps you to use AI in all your development process.

## Cómo preparar un remoto y crear un pull request

Si al ejecutar los comandos habituales ves errores relacionados con `git push` o con la creación de un PR, el problema más común es que el repositorio local no tiene ningún remoto configurado. Sigue estos pasos para dejarlo todo listo, de forma clara y directa:

1. Comprueba que no existe un remoto configurado:

   ```bash
   git remote -v
   ```

   Si el comando no muestra nada, confirma que hay que añadir el remoto.

2. Añade el remoto que apunta a tu repositorio alojado (por ejemplo, en GitHub):

   ```bash
   git remote add origin https://github.com/tu-usuario/tu-repo.git
   ```

   Sustituye la URL por la que corresponda a tu repositorio.

3. Envía la rama actual al remoto recién configurado. Si la rama se llama `work`, ejecuta:

   ```bash
   git push -u origin work
   ```

   El indicador `-u` deja configurado el seguimiento para futuros `git push`/`git pull`.

4. Abre el pull request desde la plataforma remota (GitHub, GitLab, etc.), comparando la rama `work` con la rama base (por ejemplo, `main`). Desde GitHub puedes hacerlo con el botón “Compare & pull request” que aparece tras el `push`.

Siguiendo esta secuencia te aseguras de que el remoto está definido y de que tu rama llega al servidor, evitando el error inesperado que aparece cuando se intenta crear un PR sin haber configurado el remoto.
