<template>
    <tr>
        <th scope="row">{{ index }}</th>
        <td>{{ option.name }}</td>
        <td>
            <div class="row">
                <!-- <form @submit.prevent="onUpdate" class="ml-2 mr-3">
                    <button class="btn btn-primary" type="submit">Update</button>
                </form> -->
                <form @submit.prevent="onDelete" class="ml-2">
                    <button class="btn btn-danger" type="submit">Delete</button>
                </form>
            </div>
        </td>
    </tr>
</template>

<script>
export default {
    name: "OptionsRow",
    props: {
        index: Number,
        option: Object
    },
    emits: ['refresh-ui'],
    methods: {
        async onDelete() {
            console.log("click");
            const url = 'api/Options/' + this.option.id;
            await fetch(url, {
                method: 'DELETE'
            });

            this.$emit('refresh-ui');
        },
        // onUpdate() {
        //     this.$store.commit('setOption', this.option);
        //     this.$router.push({ name: 'OptionForm' });
        // }
    }

}
</script>