<template>
    <div class="row d-flex justify-content-center align-items-center h-100 mt-5">
        <div class="col-12 col-md-9 col-lg-7 col-xl-6">
            <div class="card" style="border-radius: 15px;">
                <div class="card-body p-5">
                    <h4 class="text-uppercase text-center mb-5">Create Question</h4>
                    <form ref="questionsForm" @submit.prevent="submitForm">
                        <div class="form-outline mb-4">
                            <input type="text" id="title" class="form-control" v-model="title" />
                            <label class="form-label" for="title">Title</label>
                        </div>
                        <button type="button" class="btn btn-success btn-block" data-toggle="modal"
                            data-target="#OptionsModalForm">Create Options</button>
                        <OptionsForm Id="OptionsModalForm" @option-added="onOptionAdded">
                        </OptionsForm>
                        <h5 class="mt-5">Choose right answer...</h5>
                        <table class="table" v-if="options.length">
                            <tbody>
                                <tr v-for="(item, index) in options" :key="index">
                                    <th scope="row">
                                        <div class="form-check">
                                            <input class="form-check-input" type="radio" name="rightAnswer"
                                                id="rightAnswer" :value="item" v-model="answer">
                                        </div>
                                    </th>
                                    <td>{{ item }}</td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="form-outline mt-5 mb-4">
                            <input type="number" id="timeLimit" class="form-control" v-model="timeLimit" />
                            <label class="form-label" for="timeLimit">Time Limit</label>
                        </div>
                        <div>
                            <button type="submit" class="btn btn-primary">Create</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import OptionsForm from "./OptionsForm.vue";

export default {
    name: 'CreateQuestion',
    components: {
        OptionsForm
    },
    data() {
        return {
            title: '',
            options: [],
            timeLimit: '',
            answer: ''
        }
    }
    ,
    methods: {
        onOptionAdded(name) {
            console.log("Created" + name);
            this.options.push(name);
        },
        async submitForm() {
            const data = JSON.stringify({
                questionTitle: this.title,
                questionTimeLimit: this.timeLimit,
                options: this.options,
                answer: this.answer
            });

            console.log(data);

            await fetch('api/Questions', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: data
            });

            this.options = [];
            this.$refs.questionsForm.reset();
        }
    }
}
</script>