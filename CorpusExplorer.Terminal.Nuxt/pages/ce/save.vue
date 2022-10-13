<template>
  <div>
      <div style="margin-top:20px">Projekt speichern</div>
      <small>
        Das Projekt wird im aktuellen Ordner unter dem Projektnamen gespeichert.
      </small>
      <FileManagerSaveStandalone style="margin-top:20px" Label="Projektnamen hier eingeben..." Filter=".proj5"></FileManagerSaveStandalone>
  </div>
</template>

<script>
export default {
    name: "CeSave",
};
</script>
