<template>
    <div>

    </div>
</template>

<script>
    export default {
        name: 'NewIndex',
        mounted() {
            console.log('mounted');
            const router = useRouter();
            router.push('/snapshot/');
        },
    }
</script>