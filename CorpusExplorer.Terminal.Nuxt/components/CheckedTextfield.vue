<template>
    <v-text-field 
    :prepend-icon="checked ? 'mdi-checkbox-marked' : 'mdi-checkbox-blank-outline'" 
    :label="checked == '' ? 'Bitte setzen Sie zuerst den Haken links, um die Eingabe zu aktivieren.': emptyValue" 
    v-model="value"
    @click:prepend="switchState"
    :readonly="!checked"/>
</template>

<script>
export default {
    props: {
        checked: {
            type: Boolean,
            default: false
        },
        label: {
            type: String,
            default: 'Label'
        },
        value: {
            type: String,
            default: ''
        },
        emptyValue: {
            type: String,
            default: ''
        }
    },
    data() {
        return {
            checked: this.checked,
            label: this.label,
            value: this.value,
            emptyValue: this.emptyValue
        }
    },
    methods: {
        switchState() {
            this.$data.checked = !this.$data.checked;
        }
    }
}
</script>

<style></style>